namespace ReportManager.Domain;

/// <summary>
///     A leaf <see cref="Rule" /> used to determine if a <see cref="QuestionResponse" /> matches a set of acceptable
///     values.
/// </summary>
/// <param name="questionId"></param>
/// <param name="values"></param>
public class MatchRule(string questionId, string[] values) : Rule
{
    public override bool Apply(QuestionResponse response, Survey survey, out string? adjustedResponse)
    {
        adjustedResponse = null;
        return values.Contains(survey[questionId].Response);
    }
}
