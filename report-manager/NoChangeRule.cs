namespace Report_Manager;

/// <remarks>
///     The original leaf <see cref="Rule" /> for determining if a <see cref="QuestionResponse" /> matched any
///     approved values.
/// </remarks>
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
        return _selections.Contains(response.Response);
    }
}
