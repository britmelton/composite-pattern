namespace Report_Manager;

public class RuleSet
{
    private readonly Dictionary<string, RootRule> _rules = new();

    public void Add(string questionId, Rule rule)
    {
        if (!_rules.ContainsKey(questionId))
        {
            var rootRule = new RootRule(rule);
            _rules.Add(questionId, rootRule);
            return;
        }

        _rules[questionId].Add(rule);
    }

    public QuestionResponse Apply(QuestionResponse response, Survey survey)
    {
        if (!_rules.ContainsKey(response.QuestionId))
            return response;

        _rules[response.QuestionId].Apply(response, survey);
        return _rules[response.QuestionId].Response;
    }
}

/// <summary>
///     component
/// </summary>
public abstract class Rule
{
    public QuestionResponse Response { get; protected set; }
    public abstract bool Apply(QuestionResponse response, Survey survey);

    public virtual bool Apply(QuestionResponse response, Survey survey, out QuestionResponse adjustedValue)
    {
        adjustedValue = Response;
        return true;
    }
}

/// <summary>
///     composite
/// </summary>
public class RootRule : Rule
{
    private readonly List<Rule> _rules = new();

    public RootRule(Rule rule)
    {
        _rules.Add(rule);
    }

    public RootRule Add(Rule rule)
    {
        _rules.Add(rule);
        return this;
    }

    public override bool Apply(QuestionResponse questionResponse, Survey survey)
    {
        var noChangeRule = _rules.First();

        if (noChangeRule.Apply(questionResponse, survey))
        {
            Response = noChangeRule.Response;
            return true;
        }

        foreach (var r in _rules.Except(new List<Rule> { noChangeRule }))
            if (r.Apply(questionResponse, survey))
            {
                Response = r.Response;
                break;
            }

        return true;
    }
}

/// <summary>
///     leaf
/// </summary>
[Obsolete("replace with MatchRule")]
public class NoChangeRule : Rule
{
    private readonly string[] _selections;

    public NoChangeRule(string[] selections)
    {
        _selections = selections;
    }

    public override bool Apply(QuestionResponse response, Survey survey)
    {
        if (_selections.Contains(response.Response))
        {
            Response = new QuestionResponse(response.QuestionId, response.Response);
            return true;
        }

        return false;
    }
}

/// <summary>
///     composite
/// </summary>
public class AllRule : Rule
{
    private readonly string _overrideValue;
    private readonly List<Rule> _rules = new();

    public AllRule(string overrideValue)
    {
        _overrideValue = overrideValue;
    }

    public AllRule Add(Rule rule)
    {
        _rules.Add(rule);
        return this;
    }

    public override bool Apply(QuestionResponse response, Survey survey)
    {
        if (_rules.All(x => x.Apply(response, survey)))
        {
            Response = new QuestionResponse(response.QuestionId, _overrideValue);
            return true;
        }

        return false;
    }
}

/// <summary>
///     leaf
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

    public override bool Apply(QuestionResponse response, Survey survey) =>
        _values.Contains(survey[_questionId].Response);
}
