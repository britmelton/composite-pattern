namespace ReportManager;

public interface IRuleSetRepository
{
    RuleSet Find(Guid surveyId);
}
