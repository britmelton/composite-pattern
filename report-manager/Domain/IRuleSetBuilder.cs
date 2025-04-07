namespace ReportManager.Domain;

public interface IRuleSetBuilder
{
    IRuleSetBuilder Add(MatchRuleArgs matchRule);
    IRuleSetBuilder NextQuestion(string questionId);

    /// <summary>
    ///     Selects the most recent rule.
    /// </summary>
    IRuleSetBuilder SelectLast();
}

public record MatchRuleArgs(
    string QuestionId,
    string TargetQuestionId,
    IEnumerable<string>? TargetValues,
    string? ReplacementValue = null
);

public interface IRuleSetRepository2
{
    IRuleSetRepository2 Find();
    IRuleSetRepository2 Find(string path);
    IRuleSetRepository2 With(IRuleSetBuilder builder);
}
