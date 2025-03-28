namespace ReportManager.Domain;

public interface IRuleSetRepository
{
    RuleSet Find(string path);
    RuleSet Find(Guid surveyId);
}
