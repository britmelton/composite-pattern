namespace ReportManager.Domain;

/// <summary>
///     A repository for fetching rule sets that can produce different implementations based on the provided
///     <see cref="IDepthFirstRuleSetBuilder" />.
/// </summary>
public interface IAdvancedRuleSetRepository
{
    IAdvancedRuleSetRepository Find(Guid surveyId);
    IAdvancedRuleSetRepository Find(string path);
    IAdvancedRuleSetRepository With(IDepthFirstRuleSetBuilder builder);
}
