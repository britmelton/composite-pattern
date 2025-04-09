namespace ReportManager.Domain;

/// <summary>
///     Provides an interface for building tree-shaped rule sets by populating depth-first.
/// </summary>
public interface IDepthFirstRuleSetBuilder
{
    /// <summary>
    ///     Adds a match rule to the current tree node.
    ///     If the tree node is a match rule R, it replaces the node with an all rule containing both R and the new match rule.
    /// </summary>
    /// <param name="args">A DTO containing all the necessary data for constructing a match rule.</param>
    /// <returns>The <see cref="IDepthFirstRuleSetBuilder" /> as part of a fluent interface.</returns>
    /// <remarks>The builder keeps track of the current tree node. The added rule will be selected after this method executes.</remarks>
    IDepthFirstRuleSetBuilder Add(MatchRuleArgs args);

    /// <summary>
    ///     Begins the construction of a new rule tree for the given question.
    /// </summary>
    /// <param name="questionId">The identifier of the question to start configuring.</param>
    /// <returns>The <see cref="IDepthFirstRuleSetBuilder" /> as part of a fluent interface.</returns>
    IDepthFirstRuleSetBuilder NextQuestion(string questionId);

    /// <summary>
    ///     Selects the current node's parent if possible.
    /// </summary>
    /// <returns>The <see cref="IDepthFirstRuleSetBuilder" /> as part of a fluent interface.</returns>
    IDepthFirstRuleSetBuilder SelectPrevious();

    public record MatchRuleArgs(
        string QuestionId,
        string TargetQuestionId,
        IEnumerable<string>? TargetValues,
        string? ReplacementValue = null
    );
}
