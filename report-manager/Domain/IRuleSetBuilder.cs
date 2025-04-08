using ReportManager.Domain.Summaries;

namespace ReportManager.Domain;

/// <summary>
///     Provides and interface for building some kind of rule set by populating depth-first.
/// </summary>
public interface IRuleSetBuilder
{
    /// <summary>
    ///     Adds a <see cref="MatchRule" /> and selects it.
    /// </summary>
    /// <param name="matchRule"></param>
    /// <returns></returns>
    IRuleSetBuilder Add(MatchRuleArgs matchRule);

    IRuleSetBuilder NextQuestion(string questionId);
    IRuleSetBuilder SelectPrevious();
}

public record MatchRuleArgs(
    string QuestionId,
    string TargetQuestionId,
    IEnumerable<string>? TargetValues,
    string? ReplacementValue = null
);
