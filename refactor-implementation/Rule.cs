namespace Refactor.Implementation;

/// <summary>
/// Component
/// </summary>
public abstract class Rule
{
    protected Foo Foo { get; }

    protected Rule(Foo foo)
    {
        Foo = foo;
    }

    public abstract bool Evaluate();
}
