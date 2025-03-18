namespace First.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class EvenRule : Rule
{
    public override bool Evaluate(decimal x)
    {
        return x % 2 == 0;
    }
}