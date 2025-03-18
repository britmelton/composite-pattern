namespace Refactor.Implementation;

/// <summary>
/// Composite
/// </summary>
public class AllRule : Rule
{
    private readonly List<Rule> _rules = new();

    public AllRule(Foo foo) : base(foo) 
    {
    }

    public void Add(Rule rule)
    {
        _rules.Add(rule);
    }

    public override bool Evaluate()
    {
        if (_rules.Any(r => !r.Evaluate()))
        {
            return false;
        }

        return true;
    }
}