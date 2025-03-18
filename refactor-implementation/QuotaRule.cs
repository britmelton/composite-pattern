namespace Refactor.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class QuotaRule : Rule
{
    private readonly decimal _quota;

    public QuotaRule(Foo foo, decimal quota) : base(foo)
    {
        _quota = quota;
    }

    public override bool Evaluate() => Foo.Values.All(x => x <= _quota);
}