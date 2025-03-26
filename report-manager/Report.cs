namespace ReportManager;

public partial class Report
{
    private readonly Dictionary<string, string> _responses = new();

    private Report()
    {
    }

    public string this[string questionId] => _responses[questionId];

    private Report Add(string questionId, string response)
    {
        _responses.Add(questionId, response);
        return this;
    }
}
