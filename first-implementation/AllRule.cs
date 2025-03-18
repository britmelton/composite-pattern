namespace First.Implementation;

/// <summary>
/// Composite
/// </summary>
public class AllRule : Rule
{
    private readonly List<Rule> _rules = new();

    public void Add(Rule rule)
    {
        _rules.Add(rule);
    }

    public override bool Evaluate(decimal x)
    {
        if(_rules.Any(r => !r.Evaluate(x)))
        {
            return false;
        }

        return true;
    }
}