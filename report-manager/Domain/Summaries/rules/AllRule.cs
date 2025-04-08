using System.Text;

namespace ReportManager.Domain.Summaries;

public class AllRule(params Rule[] rules) : CompositeRule(rules)
{
    public override string GetString(int currentLevel)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Indent(currentLevel)}if ALL of the following then answer is:");

        foreach (var child in Children)
            sb.AppendLine(child.GetString(currentLevel + 1));

        return sb.ToString();
    }
}
