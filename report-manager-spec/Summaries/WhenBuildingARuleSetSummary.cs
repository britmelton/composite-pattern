using ReportManager.Domain.Summaries;
using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec.Summaries;

public class WhenBuildingARuleSetSummary
{
    #region Setup

    private readonly RuleSetSummary.Builder _builder = new();

    #endregion

    #region Requirements

    [Fact]
    public void Then()
    {
        var repo = new FlexibleRuleSetRepository(new QuestionConfigRepository());

        repo.With(_builder)
            .Find(new TestFilePathProvider().GetPath("test.json"));

        var summary = _builder.GetSummary();
        var text = summary.ToString();

        var expected = """
                       Q1:
                         Q1 is 1, 2, 98, or 99
                       Q2:
                         Q2 is 1, 2, 98, or 99
                         if ALL of the following then answer is:
                           Q2 is null
                           DISTRIB is 2
                       """;

        text.Should().Be(expected);
    }

    #endregion
}
