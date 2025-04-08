namespace ReportManager.Domain;

/// <summary>
///     A repository for fetching rule sets that can produce different implementations based on the provided
///     <see cref="IRuleSetBuilder" />.
/// </summary>
public interface IFlexibleRuleSetRepository
{
    IFlexibleRuleSetRepository Find();
    IFlexibleRuleSetRepository Find(string path);
    IFlexibleRuleSetRepository With(IRuleSetBuilder builder);
}
