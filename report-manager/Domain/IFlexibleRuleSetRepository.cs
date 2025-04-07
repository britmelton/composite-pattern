namespace ReportManager.Domain;

public interface IFlexibleRuleSetRepository
{
    IFlexibleRuleSetRepository Find();
    IFlexibleRuleSetRepository Find(string path);
    IFlexibleRuleSetRepository With(IRuleSetBuilder builder);
}
