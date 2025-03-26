namespace ReportManager;

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

    public override bool Apply(QuestionResponse questionResponse, Survey survey, out string? adjustedResponse)
    {
        adjustedResponse = null;

        foreach (var rule in _rules)
            if (rule.Apply(questionResponse, survey, out adjustedResponse))
                break; // currently, the method exits once any top-level rule has been successfully applied

        return true;
    }
}
