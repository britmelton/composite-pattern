using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec;

public class ReportBuilderSpec
{
    #region Requirements

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

        var report = Report.Builder.Build(survey, ruleSet);

        report["Q1"].Should().Be("99");
    }

    [Fact]
    public void WhenTranslatingANoChange_WithSelectionsMatch_ThenReportResponseIsSetToSurveyResponse()
    {
        const string questionId = "Q1";
        const string response = "1";

        var survey = new Survey(new QuestionResponse(questionId, response));
        var ruleSet = ObjectProvider.GetBasicRuleSet();

        var report = Report.Builder.Build(survey, ruleSet);

        report[questionId].Should().Be(response);
    }

    #endregion
}
