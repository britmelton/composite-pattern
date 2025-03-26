namespace ReportManager.Domain;

public interface IRuleSetRepository
{
    RuleSet Find(Guid surveyId);
}
