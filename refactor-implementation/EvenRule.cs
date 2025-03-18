namespace Refactor.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class EvenRule : Rule
{
    public EvenRule(Foo foo) : base(foo)
    {
    }

    public override bool Evaluate()
    {
        return Foo.Values.All(x => x % 2 == 0);
    }
}
