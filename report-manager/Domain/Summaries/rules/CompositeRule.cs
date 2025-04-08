namespace ReportManager.Domain.Summaries;

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
