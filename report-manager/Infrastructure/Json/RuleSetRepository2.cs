using ReportManager.Domain;

namespace ReportManager.Infrastructure.Json;

/// <remarks>Is a director in the builder design pattern.</remarks>
public class RuleSetRepository2(IQuestionConfigRepository qcRepo) : IRuleSetRepository2
{
    private IRuleSetBuilder _builder;

    public IRuleSetRepository2 Find() => throw new NotSupportedException();

    public IRuleSetRepository2 Find(string path)
    {
        var questionConfigs = qcRepo.Find(path);

        foreach (var q in questionConfigs)
        {
            _builder
                .NextQuestion(q.QuestionId)
                .SelectLast()
                .Add(new MatchRuleArgs(q.QuestionId, q.QuestionId, q.Selections));

            foreach (var r in q.Rules)
            foreach (var c in r.Conditions)
                _builder
                    .Add(new MatchRuleArgs(q.QuestionId, c.QuestionId, c.Values))
                    .SelectLast();
        }

        return this;
    }

    public IRuleSetRepository2 With(IRuleSetBuilder builder)
    {
        _builder = builder;
        return this;
    }
}
