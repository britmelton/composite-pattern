using System.Text;

namespace ReportManager.Domain.Summaries;

/// <summary>
///     A rule set primarily for humans to read.
/// </summary>
public partial class RuleSetSummary
{
    private string? _text;

    public override string ToString()
    {
        if (_text is not null)
            return _text;

        var sb = new StringBuilder();

        foreach (var (questionId, rule) in _rules)
            sb
                .AppendLine($"{questionId}:")
                .Append(rule.GetString(0));

        return _text = sb.ToString().TrimEnd();
    }
}
