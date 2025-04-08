namespace ReportManager.Domain.Reporting;

public partial class Rule : INode<Rule>
{
    protected readonly Node<Rule> Node = new();

    public INode<Rule>? Parent => Node.Parent;

    public virtual INode<Rule> Add(INode<Rule> node) => Node.Add(node);
    public virtual INode<Rule> Add(MatchRuleArgs args) => Add((MatchRule) args);
    public INode<Rule> Orphan() => Node.Orphan();
    public INode<Rule> Prune(INode<Rule> node) => Node.Prune(node);
    public INode<Rule> SetParent(INode<Rule> node) => Node.SetParent(node);
}
