namespace ReportManager.Domain.Reporting;

public class AllRule : Rule
{
    public AllRule(string replacementValue, params INode<Rule>[] rules)
    {
        ReplacementValue = replacementValue;
        foreach (var rule in rules)
            Node.Add(rule);
    }

    public string ReplacementValue { get; }

    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        var isSatisfied = Node.All(x => ((Rule) x).Apply(response, survey, out var adjustedResponse));

        adjustedResponse = isSatisfied
            ? ReplacementValue
            : null;

        return isSatisfied;
    }
}
