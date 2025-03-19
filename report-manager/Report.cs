namespace Report_Manager;

public partial class Report
{
    private readonly Dictionary<string, QuestionResponse> _questionResponses = new();

    private Report()
    {
    }

    public string this[string questionId] => _questionResponses[questionId].Response;

    private Report Add(string questionId, QuestionResponse adjustedResponse)
    {
        _questionResponses.Add(questionId, adjustedResponse);
        return this;
    }
}
