namespace ReportManager;

public class RuleSet
{
    private readonly Dictionary<string, RootRule> _rules = new();

    public RuleSet Add(string questionId, Rule rule)
    {
        if (_rules.TryGetValue(questionId, out var rootRule))
            rootRule.Add(rule);
        else
            _rules.Add(questionId, new RootRule(rule));

        return this;
    }

    public string Apply(QuestionResponse questionResponse, Survey survey)
    {
        var (questionId, response) = questionResponse;

        if (!_rules.TryGetValue(questionId, out var rule))
            return response;

        rule.Apply(questionResponse, survey, out var adjustedResponse);

        return adjustedResponse ?? response;
    }
}
