namespace Report_Manager;

/// <summary>
///     leaf
/// </summary>
[Obsolete("replace with MatchRule")]
public class NoChangeRule : Rule
{
    private readonly string[] _selections;

    public NoChangeRule(string[] selections)
    {
        _selections = selections;
    }

    public override bool Apply(QuestionResponse response, Survey survey, out QuestionResponse? adjustedResponse)
    {
        adjustedResponse = null;

        if (!_selections.Contains(response.Response))
            return false;

        adjustedResponse = new QuestionResponse(response.QuestionId, response.Response);

        return true;
    }
}
