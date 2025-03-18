namespace First.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class OddRule : Rule
{
    public override bool Evaluate(decimal x)
    {
        return x % 2 == 1;
    }
}
