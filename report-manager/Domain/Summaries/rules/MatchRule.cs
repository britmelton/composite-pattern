using System.Text;

namespace ReportManager.Domain.Summaries;

public class MatchRule(
    string targetQuestionId,
    IEnumerable<string> targetValues
) : Rule
{
    public override Rule Add(Rule rule)
    {
        Parent.Prune(this)
            .Add(new AllRule(this, rule));

        return rule;
    }

    public override string GetString(int currentLevel)
    {
        var sb = new StringBuilder();
        sb.Append($"{Indent(currentLevel)}{targetQuestionId} is ");

        var last = targetValues.Last();
        var values = string.Join(", ", targetValues).Replace($", {last}", $", or {last}");
        sb.Append(values);

        return sb.ToString();
    }

    public static implicit operator MatchRule(IDepthFirstRuleSetBuilder.MatchRuleArgs source) =>
        new(
            source.TargetQuestionId,
            source.TargetValues
        );
}
