using ReportManager.Domain.Legacy.Reporting;
using Reporting_IRuleSetRepository = ReportManager.Domain.Legacy.Reporting.IRuleSetRepository;

namespace ReportManager.Infrastructure.Json;

public class RuleSetRepository(IQuestionConfigRepository qcRepo) : Reporting_IRuleSetRepository
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
