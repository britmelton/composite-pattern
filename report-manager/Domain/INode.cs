namespace ReportManager.Domain;

public interface INode<T>
{
    INode<T>? Parent { get; }
    INode<T> Add(INode<T> node);
    INode<T> Add(MatchRuleArgs args);
    INode<T> Orphan();
    INode<T> Prune(INode<T> node);
    INode<T> SetParent(INode<T> node);
}
