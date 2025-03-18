namespace Report_Manager;

public class Survey
{
    public List<QuestionResponse> Responses { get; } = new();
    public QuestionResponse? this[string questionId] => Responses.SingleOrDefault(x => x.QuestionId == questionId);
    public Survey(params QuestionResponse[] values)
    {
        Responses.AddRange(values);
    }
}

public class QuestionResponse
{
    public string QuestionId { get; set; }
    public string Response { get; set; }
    public QuestionResponse(string questionId, string response)
    {
        QuestionId = questionId;
        Response = response;
    }
}