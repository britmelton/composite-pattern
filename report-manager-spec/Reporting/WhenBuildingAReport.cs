using ReportManager.Domain.Legacy.Reporting;

namespace ReportManagerSpec.Reporting;

public class WhenBuildingAReport
{
    #region Implementation

    public static IEnumerable<object[]> GetRuleSets()
    {
        yield return [ObjectProvider.GetJsonRuleSet()];
        yield return [ObjectProvider.GetDbRuleSet()];
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetRuleSets))]
    public void WithAcceptableResponse_ThenReportResponseIsSurveyResponse(RuleSet ruleSet)
    {
        const string questionId = "Q1", response = "1";
        var survey = new Survey(new QuestionResponse(questionId, response));

        var report = Report.From(survey, ruleSet);

        report[questionId].Should().Be(response);
    }

    [Theory]
    [MemberData(nameof(GetRuleSets))]
    public void WithApplicableMatchAll_ThenReportResponseIsTargetValue(RuleSet ruleSet)
    {
        var survey = new Survey(
            new("DISTRIB", "2"),
            new("Q1", "1"),
            new("Q2", "null")
        );

        var report = Report.From(survey, ruleSet);

        report["Q2"].Should().Be("99");
    }

    #endregion
}
