namespace ReportManager.Domain.Reporting;

public partial class Rule
{
    private readonly List<Rule> _children = [];

    public Rule? Parent { get; private set; }

    public virtual Rule Add(Rule rule)
    {
        rule.SetParent(this);
        _children.Add(rule);
        return rule;
    }

    public virtual Rule Add(IDepthFirstRuleSetBuilder.MatchRuleArgs args) => Add((MatchRule) args);

    public Rule Orphan()
    {
        Parent = null;
        return this;
    }

    public Rule Prune(Rule node)
    {
        if (!_children.Contains(node))
            return this;


        _children.Remove(node);
        node.Orphan();
        return this;
    }

    public Rule SetParent(Rule rule)
    {
        Parent = rule;
        return this;
    }
}
