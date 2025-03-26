namespace ReportManager.Infrastructure.Database;

public class RuleSet
{
    public Guid SurveyId { get; set; }
    public IEnumerable<Rule> Rules { get; set; } = [];
}
