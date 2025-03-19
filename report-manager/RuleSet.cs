namespace Report_Manager;

public partial class RuleSet
{
    private readonly Dictionary<string, RootRule> _rules = new();

    public void Add(string questionId, Rule rule)
    {
        if (_rules.TryGetValue(questionId, out var rootRule))
        {
            rootRule.Add(rule);
            return;
        }

        _rules.Add(questionId, new RootRule(rule));
    }

    public QuestionResponse Apply(QuestionResponse response, Survey survey)
    {
        if (!_rules.TryGetValue(response.QuestionId, out var rule))
            return response;

        rule.Apply(response, survey, out var adjustedResponse);

        return adjustedResponse ?? response;
    }
}
