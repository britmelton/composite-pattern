using System.Text;

namespace ReportManager.Domain.Summaries;

public class RootRule(params Rule[] rules) : CompositeRule(rules)
{
    public override string GetString(int currentLevel)
    {
        var sb = new StringBuilder();

        foreach (var child in Children)
            sb.AppendLine(child.GetString(currentLevel + 1));

        return sb.ToString();
    }
}
