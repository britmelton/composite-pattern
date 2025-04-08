namespace ReportManager.Domain.Reporting;

public class AnyRule : Rule
{
    public string ReplacementValue { get; }

    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        var isSatisfied = Node.Any(x => ((Rule) x).Apply(response, survey, out var adjustedResponse));

        adjustedResponse = isSatisfied
            ? ReplacementValue
            : null;

        return isSatisfied;
    }
}
