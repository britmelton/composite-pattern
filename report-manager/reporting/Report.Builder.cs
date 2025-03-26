namespace ReportManager;

public partial class Report
{
    private Report()
    {
    }

    private Report Add(string questionId, string response)
    {
        _responses.Add(questionId, response);
        return this;
    }

    /// <remarks>Structured this way to prevent incorrect creating/altering of <see cref="Report" />s.</remarks>
    public class Builder
    {
        public static Report Build(Survey survey, RuleSet ruleSet)
        {
            var report = new Report();

            foreach (var questionResponse in survey)
            {
                var response = ruleSet.Apply(questionResponse, survey);
                report.Add(questionResponse.QuestionId, response);
            }

            return report;
        }
    }
}
