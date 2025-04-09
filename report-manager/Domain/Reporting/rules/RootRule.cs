namespace ReportManager.Domain.Reporting;

public class RootRule : Rule
{
    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        adjustedResponse = null;

        foreach (var rule in this)
            if (rule.Apply(response, survey, out adjustedResponse))
                break; // currently, the method exits once any top-level rule has been successfully applied

        return true;
    }
}
