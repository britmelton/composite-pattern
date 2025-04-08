using ReportManager.Domain;

namespace ReportManager.Infrastructure.Json;

public class FlexibleRuleSetRepository(IQuestionConfigRepository qcRepo) : IFlexibleRuleSetRepository
{
    private IRuleSetBuilder _builder;

    public IFlexibleRuleSetRepository Find() => throw new NotSupportedException();

    public IFlexibleRuleSetRepository Find(string path)
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
                _builder.Add(new(q.QuestionId, c.QuestionId, c.Values));
        }

        return this;
    }

    public IFlexibleRuleSetRepository With(IRuleSetBuilder builder)
    {
        _builder = builder;
        return this;
    }
}
