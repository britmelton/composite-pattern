using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec;

public class ObjectProvider
{
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
