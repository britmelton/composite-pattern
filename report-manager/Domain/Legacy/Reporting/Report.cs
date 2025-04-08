namespace ReportManager.Domain.Legacy.Reporting;

public class Report
{
    private readonly Dictionary<string, string> _responses = new();

    private Report()
    {
    }

    /// <summary>
    ///     Factory method.
    ///     Creates a new <see cref="Report" /> by applying a <see cref="RuleSet" /> to a <see cref="Survey" />.
    /// </summary>
    /// <param name="ruleSet"></param>
    /// <param name="survey"></param>
    /// <returns></returns>
    public static Report From(RuleSet ruleSet, Survey survey)
    {
        var report = new Report();

        foreach (var questionResponse in survey)
        {
            var response = ruleSet.Apply(questionResponse, survey);
            report.Add(questionResponse.QuestionId, response);
        }

        return report;
    }

    public static Report From(Survey survey, RuleSet ruleSet) => From(ruleSet, survey);

    public string this[string questionId] => _responses[questionId];

    private Report Add(string questionId, string response)
    {
        _responses.Add(questionId, response);
        return this;
    }
}
