namespace Refactor.Implementation;

/// <summary>
/// Composite
/// </summary>
public class AnyRule : Rule
{
    private readonly List<Rule> _rules = new();

    public AnyRule(Foo foo) : base(foo)
    {
    }

    public void Add(Rule rule)
    {
        _rules.Add(rule);
    }

    public override bool Evaluate()
    {
        if (_rules.Any(r => r.Evaluate()))
        {
            return true;
        }

        return false;
    }
}
