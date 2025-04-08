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
