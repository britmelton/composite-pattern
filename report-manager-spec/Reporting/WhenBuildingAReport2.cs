using ReportManager.Domain.Reporting;
using ReportManager.Infrastructure.Database;
using RuleSet = ReportManager.Domain.Reporting.RuleSet;

namespace ReportManagerSpec.Reporting;

public class WhenBuildingAReport2
{
    #region Setup

    private readonly RuleSet.Builder _builder = new();
    private readonly RuleSet _ruleSet;

    public WhenBuildingAReport2()
    {
        var context = ObjectProvider.GetDbContext();
        var repo = new AdvancedRuleSetRepository(context);
        var surveyId = context.Rules.First().SurveyId;

        repo.With(_builder).Find(surveyId);

        _ruleSet = _builder.GetRuleSet();
    }

    #endregion

    #region Requirements

    [Fact]
    public void WithAcceptableResponse_ThenReportResponseIsSurveyResponse()
    {
        const string questionId = "Q1", response = "1";
        var survey = new Survey(new QuestionResponse(questionId, response));

        var report = Report.From(survey, _ruleSet);

        report[questionId].Should().Be(response);
    }

    [Fact]
    public void WithApplicableMatchAll_ThenReportResponseIsTargetValue()
    {
        var survey = new Survey(
            new("DISTRIB", "2"),
            new("Q1", "1"),
            new("Q2", "null")
        );

        var report = Report.From(survey, _ruleSet);

        report["Q2"].Should().Be("99");
    }

    #endregion
}
