namespace ReportManager.Domain;

public partial class Report
{
    private readonly Dictionary<string, string> _responses = new();

    public string this[string questionId] => _responses[questionId];
}
