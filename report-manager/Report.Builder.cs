namespace Report_Manager;

public partial class Report
{
    /// <remarks>Structured this way to prevent incorrect creating/altering of <see cref="Report" />s.</remarks>
    public class Builder
    {
        public Report Build(Survey survey, RuleSet ruleSet)
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
