using System.Collections;

namespace ReportManager.Domain;

public class Survey(params QuestionResponse[] values) : IEnumerable<QuestionResponse>
{
    private readonly IReadOnlyList<QuestionResponse> _responses = values.ToList();

    public QuestionResponse? this[string questionId] => _responses.SingleOrDefault(x => x.QuestionId == questionId);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _responses).GetEnumerator();

    public IEnumerator<QuestionResponse> GetEnumerator() => _responses.GetEnumerator();
}
