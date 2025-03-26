namespace ReportManager.Database;

public class Rule
{
    public string QuestionId { get; set; }
    public string TargetQuestionId { get; set; }
    public byte GroupNumber { get; set; }
    public bool IsGroupAll { get; set; }
    public bool IsGroupAny { get; set; }
    public string? ReplacementValue { get; set; }
    public string? TargetValues { get; set; }
}
