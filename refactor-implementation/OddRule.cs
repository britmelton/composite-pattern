namespace Refactor.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class OddRule : Rule
{
    public OddRule(Foo foo) : base(foo)
    {
    }

    public override bool Evaluate()
    {
        return Foo.Values.All(x => x % 2 == 1);
    }
}
