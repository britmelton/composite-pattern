namespace Report_Manager;

public class ReportBuilder
{
    public Report Build(Survey survey, RuleSet ruleSet)
    {
        var report = new Report();

        foreach(var response in survey.Responses)
        {
            var adjustedResponse = ruleSet.Apply(response, survey);
            report.Add(response.QuestionId, adjustedResponse);
        }
        return report;
    }
}

public class Report
{
    private Dictionary<string, QuestionResponse> _questionResponses = new();

    public string this[string questionId] => _questionResponses[questionId].Response;

    public void Add(string questionId, QuestionResponse adjustedResponse)
    {
        _questionResponses.Add(questionId, adjustedResponse);
    }
}
