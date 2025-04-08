namespace ReportManager.Domain.Reporting;

public partial class RuleSet
{
    private readonly Dictionary<string, Rule> _rules = [];

    public Rule Add(string questionId)
    {
        var root = new RootRule();
        _rules.Add(questionId, root);
        return root;
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
