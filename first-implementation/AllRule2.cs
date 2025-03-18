namespace First.Implementation;

/// <summary>
/// Composite
/// </summary>
public class AllRule2 : Rule
{
    private readonly List<Rule> _rules = new();

    public AllRule2(params Rule[] rules)
    {
        _rules.AddRange(rules);
    }

    public override bool Evaluate(decimal x)
    {
        if (_rules.Any(r => !r.Evaluate(x)))
        {
            return false;
        }

        return true;
    }
}