namespace Report_Manager_Spec;

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

        var ruleSet = new RuleSet.Builder()
            .Load(ObjectProvider.GetMatchRules())
            .Build()
            .GetRuleSet();

        var report = new Report.Builder().Build(survey, ruleSet);

        report["Q1"].Should().Be("99");
    }

    [Fact]
    public void WhenTranslatingANoChange_WithSelectionsMatch_ThenReportResponseIsSetToSurveyResponse()
    {
        var survey = new Survey(new QuestionResponse("Q1", "1"));

        var questionConfigs = new List<QuestionConfig>
        {
            new()
            {
                QuestionId = "Q1",
                Selections = ["1", "2", "98", "99"],
                Rules = []
            }
        };

        var ruleSet = new RuleSet.Builder()
            .Load(questionConfigs)
            .Build()
            .GetRuleSet();

        var report = new Report.Builder().Build(survey, ruleSet);

        report["Q1"].Should().Be("1");
    }

    #endregion
}
