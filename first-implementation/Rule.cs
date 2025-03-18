namespace First.Implementation;

/// <summary>
/// Component
/// </summary>
public abstract class Rule
{
    /// <summary>
    /// Returns true if the rule is satisfied
    /// </summary>
    /// <param name="x">The value being evaluated against the rule.</param>
    /// <returns></returns>
    public abstract bool Evaluate(decimal x);
}

