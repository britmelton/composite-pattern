namespace ReportManager.Domain;

/// <summary>
///     A composite <see cref="Rule" /> that overrides a <see cref="QuestionResponse" /> if all its children are satisfied.
/// </summary>
public class AllRule : Rule
{
    private readonly string _overrideValue;
    private readonly List<Rule> _rules = [];

    public AllRule(string overrideValue, IEnumerable<Rule> rules)
    {
        _overrideValue = overrideValue;
        _rules.AddRange(rules);
    }

    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        var isSatisfied = _rules.All(x => x.Apply(response, survey, out var adjustedResponse));

        adjustedResponse = isSatisfied
            ? _overrideValue
            : null;

        return isSatisfied;
    }
}
