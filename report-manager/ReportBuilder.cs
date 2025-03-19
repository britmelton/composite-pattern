namespace Report_Manager;

public partial class Report
{
    /// <remarks>Structured this way to prevent incorrect creating/altering of <see cref="Report" />s.</remarks>
    public class Builder
    {
        public Report Build(Survey survey, RuleSet ruleSet)
        {
            var report = new Report();

            foreach (var response in survey)
            {
                var reportResponse = ruleSet.Apply(response, survey);
                report.Add(response.QuestionId, reportResponse);
            }

            return report;
        }
    }
}
