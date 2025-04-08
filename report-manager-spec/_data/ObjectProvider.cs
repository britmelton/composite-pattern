using ReportManager.Infrastructure.Json;
using RuleSet = ReportManager.Domain.Legacy.Reporting.RuleSet;
using DbRule = ReportManager.Infrastructure.Database.Rule;
using DbRuleSetRepository = ReportManager.Infrastructure.Database.RuleSetRepository;
using JsonRuleSetRepository = ReportManager.Infrastructure.Json.RuleSetRepository;

namespace ReportManagerSpec;

public class ObjectProvider
{
    public static RuleSet GetDbRuleSet()
    {
        var surveyId = Guid.NewGuid();

        var seed = new List<DbRule>
        {
            new("Q1", surveyId, "Q1", 0, true, false, null, "1,2,98,99"),
            new("Q2", surveyId, "Q2", 1, true, false, "99", "1,2,98,99"),
            new("Q2", surveyId, "Q2", 2, true, false, "99", "null"),
            new("Q2", surveyId, "DISTRIB", 2, true, false, "99", "2")
        };

        var context = new DbContext(seed);

        return new DbRuleSetRepository(context).Find(surveyId);
    }

    public static RuleSet GetJsonRuleSet()
    {
        var path = new TestFilePathProvider().GetPath("test.json");

        return new JsonRuleSetRepository(new QuestionConfigRepository()).Find(path);
    }
}
