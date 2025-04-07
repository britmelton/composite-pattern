using System.Text;

namespace ReportManager.Domain.Summaries;

public abstract class Rule
{
    public Rule? Parent { get; private set; }

    public abstract Rule Add(Rule rule);
    public abstract string GetString(int currentLevel);

    public Rule Orphan()
    {
        Parent = null;
        return this;
    }

    public virtual Rule Prune(Rule rule) => this;

    public Rule SetParent(Rule rule)
    {
        Parent = rule;
        return this;
    }

    public static string Indent(int level) => new(' ', level * 2);
}

public abstract class CompositeRule : Rule
{
    protected readonly List<Rule> Children = [];

    protected CompositeRule(params Rule[] rules)
    {
        foreach (var rule in rules)
            Add(rule);
    }

    public override Rule Add(Rule rule)
    {
        rule.SetParent(this);
        Children.Add(rule);
        return rule;
    }

    public override Rule Prune(Rule rule)
    {
        if (!Children.Contains(rule))
            return this;

        Children.Remove(rule);
        rule.Orphan();
        return this;
    }
}

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

    public static implicit operator MatchRule(MatchRuleArgs source) =>
        new(
            source.TargetQuestionId,
            source.TargetValues
        );
}
