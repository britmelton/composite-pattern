using ReportManager.Domain.Summaries;
using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec.Summaries;

public class WhenBuildingASummary
{
    #region Requirements

    [Fact]
    public void Then()
    {
        var repo = new RuleSetRepository2(new QuestionConfigRepository());
        var builder = new Summary.Builder();

        repo.With(builder)
            .Find(new TestFilePathProvider().GetPath("test.json"));

        var ruleSet = builder.GetSummary();
        var text = ruleSet.ToString();

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
