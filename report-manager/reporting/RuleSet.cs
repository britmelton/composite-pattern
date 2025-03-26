namespace ReportManager;

public partial class RuleSet
{
    private readonly Dictionary<string, RootRule> _rules = new();

    public string Apply(QuestionResponse questionResponse, Survey survey)
    {
        var (questionId, response) = questionResponse;

        if (!_rules.TryGetValue(questionId, out var rule))
            return response;

        rule.Apply(questionResponse, survey, out var adjustedResponse);

        return adjustedResponse ?? response;
    }
}
