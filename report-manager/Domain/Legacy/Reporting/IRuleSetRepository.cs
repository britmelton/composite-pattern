namespace ReportManager.Domain.Legacy.Reporting;

public interface IRuleSetRepository
{
    RuleSet Find(string path);
    RuleSet Find(Guid surveyId);
}
