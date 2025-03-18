using FluentAssertions;
using Report_Manager;
using static Report_Manager.FilePath;

namespace Report_Manager_Spec;

public class RuleSetConfigSpec
{
    private QuestionConfigRepository _questionConfigRepo = new();

    [Fact]
    public void WhenLoadingRuleSet_ThenConfigFileIsParsed()
    {
        var configs = _questionConfigRepo.Get(RuleSetConfigFile);

        configs.Should().BeOfType<List<QuestionConfig>>();
    }
}
public class ReportBuilderSpec
{
    private ReportBuilder _reportBuilder = new();

    [Fact]
    public void WhenTranslatingANoChange_WithSelectionsMatch_ThenReportResponseIsSetToSurveyResponse()
    {
        var survey = new Survey(new QuestionResponse("Q1", "1"));

        var questionConfigs = new List<QuestionConfig>()
        {
            new QuestionConfig()
            {
                QuestionId = "Q1",
                Selections = ["1", "2", "98", "99"],
                Rules = []
            }
        };

        var ruleSet = new RuleSetBuilder()
            .Load(questionConfigs)
            .Build()
            .GetRuleSet();

        var report = _reportBuilder.Build(survey, ruleSet);

        // report.Responses.SingleOrDefault(x => x.QuestionId == "Q1").Response.Should().Be("1");
        report["Q1"].Should().Be("1");
    }

    [Fact]
    public void WhenResponseIsNotInSelection_ThenApplyAllMatchRule()
    {
        var survey = new Survey(
            new QuestionResponse("DISTRIB", "2"),
            new QuestionResponse("Q1", "null")
            );

        var ruleSet = new RuleSetBuilder()
            .Load(ObjectProvider.GetMatchRules())
            .Build()
            .GetRuleSet();

        var report = _reportBuilder.Build(survey, ruleSet);

        report["Q1"].Should().Be("99");
    }
}
