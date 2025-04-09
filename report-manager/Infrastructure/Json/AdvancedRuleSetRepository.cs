using ReportManager.Domain;

namespace ReportManager.Infrastructure.Json;

public class AdvancedRuleSetRepository(IQuestionConfigRepository qcRepo) : IAdvancedRuleSetRepository
{
    private IDepthFirstRuleSetBuilder _builder;

    public IAdvancedRuleSetRepository Find() => throw new NotSupportedException();

    public IAdvancedRuleSetRepository Find(string path)
    {
        var questionConfigs = qcRepo.Find(path);

        foreach (var q in questionConfigs)
        {
            _builder
                .NextQuestion(q.QuestionId)
                .Add(new(q.QuestionId, q.QuestionId, q.Selections))
                .SelectPrevious();

            foreach (var r in q.Rules)
            foreach (var c in r.Conditions)
                _builder.Add(new(q.QuestionId, c.QuestionId, c.Values, r.TargetValue));
        }

        return this;
    }

    public IAdvancedRuleSetRepository With(IDepthFirstRuleSetBuilder builder)
    {
        _builder = builder;
        return this;
    }
}
