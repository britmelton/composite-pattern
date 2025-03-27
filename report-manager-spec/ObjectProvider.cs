using ReportManager.Infrastructure.Database;
using ReportManager.Infrastructure.Json;
using RuleSet = ReportManager.Domain.RuleSet;
using DbRule = ReportManager.Infrastructure.Database.Rule;

namespace ReportManagerSpec;

public class ObjectProvider
{
    public static RuleSet GetAlternateRuleSet()
    {
        var surveyId = Guid.NewGuid();

        var seed = new List<DbRule>
        {
            new("Q1", surveyId, "Q1", 0, true, false, null, "1,2,98,99"),
            new("Q2", surveyId, "Q2", 1, true, false, "99", "1,2,98,99"),
            new("Q2", surveyId, "Q2", 2, true, false, "99", "null"),
            new("Q2", surveyId, "DISTRIB", 2, true, false, "99", "2")
        };

        return new RuleSetRepository(seed).Find(surveyId);
    }

    public static RuleSet GetBasicRuleSet()
    {
        var path = new TestFilePathProvider().GetPath("basic.json");
        var questionConfigs = new QuestionConfigRepository().Find(path);

        return new RuleSetBuilder()
            .Load(questionConfigs)
            .Build()
            .GetRuleSet();
    }
}
