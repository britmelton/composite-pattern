using ReportManager.Domain;

namespace ReportManager.Infrastructure.Json;

public class RuleSetSourceIterator(IEnumerable<QuestionConfig> questionConfigs) : IRuleSetSourceIterator
{
    private readonly IEnumerator<QuestionConfig> _qcs = questionConfigs.GetEnumerator();
    private IRuleSource? _current;
    private IEnumerator<QuestionCalculatedValues> _qcvs;
    private IEnumerator<QuestionWithValuesToMatch> _qwvtm;

    private bool AdvanceQuestionCalculatedValues()
    {
    }

    private bool AdvanceQuestionConfig()
    {
        bool success;

        if (success = _qcs.MoveNext())
        {
            _current = _qcs.Current;
            _qcvs = _qcs.Current.Rules.GetEnumerator();
        }

        return success;
    }

    private bool AdvanceQuestionWithValuesToMatch()
    {
    }

    public IRuleSource? GetCurrent() => _current;

    public bool Next()
    {
        if (!_qcvs.MoveNext())
            return AdvanceQuestionConfig();
    }
}

public record RuleSource(
    string QuestionId,
    string TargetQuestionId,
    IEnumerable<string> TargetQuestionValues,
 
);
