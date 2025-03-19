namespace Report_Manager;

/// <summary>
///     Represents a set of logic applied to <see cref="Survey" /> responses when building a <see cref="Report" />.
/// </summary>
/// <remarks>The component class in the composite design pattern.</remarks>
public abstract class Rule
{
    /// <summary>
    ///     Applies the <see cref="Rule" /> to the supplied <see cref="QuestionResponse" />.
    /// </summary>
    /// <param name="response">The <see cref="Survey" /> response that is being mapped to a <see cref="Report" /> response.</param>
    /// <param name="survey">The survey the response came from. Used to look up other response values if necessary.</param>
    /// <param name="adjustedResponse">The adjusted response value if an adjustment was warranted.</param>
    /// <returns>
    ///     <c>true</c> if a rule was satisfied, <c>false</c> otherwise. <c>true</c> does not guarantee an adjusted
    ///     response.
    /// </returns>
    public abstract bool Apply(
        QuestionResponse response,
        Survey survey,
        out QuestionResponse? adjustedResponse
    );
}

/// <summary>
///     Always the base <see cref="Rule" /> for a given question.
///     Responsible for applying its child rules to a <see cref="QuestionResponse" />.
/// </summary>
public class RootRule : Rule
{
    private readonly List<Rule> _rules = [];

    public RootRule(Rule rule)
    {
        _rules.Add(rule);
    }

    public RootRule Add(Rule rule)
    {
        _rules.Add(rule);
        return this;
    }

    public override bool Apply(QuestionResponse questionResponse, Survey survey, out QuestionResponse? adjustedResponse)
    {
        adjustedResponse = null;

        foreach (var rule in _rules)
            if (rule.Apply(questionResponse, survey, out adjustedResponse))
                break; // currently, the method exits once any top-level rule has been successfully applied

        return true;
    }
}

/// <summary>
///     A composite <see cref="Rule" /> that overrides a <see cref="QuestionResponse" /> if all its children are
///     satisfied.
/// </summary>
public class AllRule : Rule
{
    private readonly string _overrideValue;
    private readonly List<Rule> _rules = [];

    public AllRule(string overrideValue, IEnumerable<Rule> rules)
    {
        _overrideValue = overrideValue;
        _rules.AddRange(rules);
    }

    public override bool Apply(QuestionResponse response, Survey survey, out QuestionResponse? adjustedResponse)
    {
        var isSatisfied = _rules.All(x => x.Apply(response, survey, out var adjustedResponse));

        adjustedResponse = isSatisfied
            ? new QuestionResponse(response.QuestionId, _overrideValue)
            : null;

        return isSatisfied;
    }
}

/// <summary>
///     A leaf <see cref="Rule" /> used to determine if a <see cref="QuestionResponse" /> matches a set of acceptable
///     values.
/// </summary>
public class MatchRule : Rule
{
    private readonly string _questionId;
    private readonly string[] _values;

    public MatchRule(string questionId, string[] values)
    {
        _questionId = questionId;
        _values = values;
    }

    public override bool Apply(QuestionResponse response, Survey survey, out QuestionResponse? adjustedResponse)
    {
        adjustedResponse = null;
        return _values.Contains(survey[_questionId].Response);
    }
}
