namespace Report_Manager;

public class Survey
{
    public Survey(params QuestionResponse[] values)
    {
        Responses.AddRange(values);
    }

    public QuestionResponse? this[string questionId] => Responses.SingleOrDefault(x => x.QuestionId == questionId);
    public List<QuestionResponse> Responses { get; } = new();
}

public class QuestionResponse
{
    public QuestionResponse(string questionId, string response)
    {
        QuestionId = questionId;
        Response = response;
    }

    public string QuestionId { get; set; }
    public string Response { get; set; }
}
