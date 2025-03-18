namespace Report_Manager;

public class RuleSet
{
    private Dictionary<string, RootRule> _rules = new();

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
/// component
/// </summary>
public abstract class Rule
{
    protected Rule() { }

    public QuestionResponse Response { get; protected set; }
    public abstract bool Apply(QuestionResponse response, Survey survey);

}

/// <summary>
/// composite
/// </summary>
public class RootRule : Rule
{
    private List<Rule> _rules = new();

    public QuestionResponse Response { get; private set; }

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
        var noChangeRule = _rules.OfType<NoChangeRule>().Single();

        if (noChangeRule.Apply(questionResponse, survey))
        {
            Response = noChangeRule.Response;
            return true;
        }

        foreach (var r in _rules.Except([noChangeRule]))
        {
            if (r.Apply(questionResponse, survey))
            {
                Response = r.Response;
                break;
            }
        }

        return true;
    }
}

/// <summary>
/// leaf
/// </summary>
public class NoChangeRule : Rule
{
    private readonly string[] _selections;

    public NoChangeRule(string[] selections) : base()
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
/// composite
/// </summary>
public class AllRule : Rule
{
    private readonly List<Rule> _rules = new();
    private readonly string _overrideValue;

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
/// leaf
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

    public override bool Apply(QuestionResponse response, Survey survey)
    {
        var question = survey.Responses.SingleOrDefault(x => x.QuestionId == _questionId);

        return _values.Contains(question.Response);
    }
}