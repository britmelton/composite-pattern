using ReportManager.Domain.Reporting;

namespace ReportManager.Infrastructure.Json;

public class RuleSetRepository(IQuestionConfigRepository qcRepo) : IRuleSetRepository
{
    public RuleSet Find(string path)
    {
        var questionConfigs = qcRepo.Find(path);

        return new RuleSetBuilder()
            .Load(questionConfigs)
            .Build()
            .GetRuleSet();
    }

    public RuleSet Find(Guid surveyId) => throw new NotSupportedException();
}
