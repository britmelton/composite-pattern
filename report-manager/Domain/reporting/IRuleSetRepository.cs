namespace ReportManager.Domain.Reporting;

public interface IRuleSetRepository
{
    RuleSet Find(string path);
    RuleSet Find(Guid surveyId);
}
