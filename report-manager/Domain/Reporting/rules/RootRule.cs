namespace ReportManager.Domain.Reporting;

public class RootRule : Rule
{
    public string ReplacementValue { get; }

    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        adjustedResponse = null;

        foreach (var rule in Node)
            if (((Rule) rule).Apply(response, survey, out adjustedResponse))
                break; // currently, the method exits once any top-level rule has been successfully applied

        return true;
    }
}
