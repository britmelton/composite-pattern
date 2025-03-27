namespace ReportManager.Infrastructure.Database;

public record Rule(
    string QuestionId,
    Guid SurveyId,
    string TargetQuestionId,
    byte GroupNumber,
    bool IsGroupAll,
    bool IsGroupAny,
    string? ReplacementValue,
    string? TargetValues
);
