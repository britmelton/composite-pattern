namespace First.Implementation;

/// <summary>
/// Leaf
/// </summary>
public class QuotaRule : Rule
{
    private readonly decimal _quota;

    public QuotaRule(decimal quota)
    {
        _quota = quota;
    }

    public override bool Evaluate(decimal x) => x <= _quota;
}