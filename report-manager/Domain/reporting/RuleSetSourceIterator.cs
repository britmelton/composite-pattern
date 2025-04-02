namespace ReportManager.Domain;

public interface IRuleSource
{
    string GetQuestionId();
    string GetTargetQuestionId();
    IEnumerable<string> GetTargetValues();
}

public interface IRuleSetSourceIterator
{
    IRuleSource? GetCurrent();
    bool Next();
}
