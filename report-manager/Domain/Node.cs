using System.Collections;

namespace ReportManager.Domain;

public class Node<T> : INode<T>, IEnumerable<INode<T>>
{
    private readonly List<INode<T>> _children = [];

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<INode<T>> GetEnumerator() => _children.GetEnumerator();
    public INode<T>? Parent { get; private set; }

    public INode<T> Add(INode<T> node)
    {
        node.SetParent(this);
        _children.Add(node);
        return node;
    }

    public INode<T> Add(MatchRuleArgs args) => throw new NotImplementedException();

    public INode<T> Orphan()
    {
        Parent = null;
        return this;
    }

    public INode<T> Prune(INode<T> node)
    {
        if (!_children.Contains(node))
            return this;

        _children.Remove(node);
        node.Orphan();
        return this;
    }

    public INode<T> SetParent(INode<T> node)
    {
        Parent = node;
        return this;
    }
}
