using System.Collections;

namespace Report_Manager;

public class Survey : IEnumerable<QuestionResponse>
{
    public Survey(params QuestionResponse[] values)
    {
        Responses.AddRange(values);
    }

    public QuestionResponse? this[string questionId] => Responses.SingleOrDefault(x => x.QuestionId == questionId);
    public List<QuestionResponse> Responses { get; } = new();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) Responses).GetEnumerator();

    public IEnumerator<QuestionResponse> GetEnumerator() => Responses.GetEnumerator();
}

public class QuestionResponse
{
    public QuestionResponse(string questionId, string response)
    {
        QuestionId = questionId;
        Response = response;
    }

    public void Deconstruct(out string questionId, out string response)
    {
        questionId = QuestionId;
        response = Response;
    }

    public string QuestionId { get; set; }
    public string Response { get; set; }
}
