using FluentAssertions.Execution;
using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec;

public class RuleSetConfigSpec
{
    #region Setup

    private readonly QuestionConfigRepository _repository = new();

    #endregion

    #region Requirements

    [Fact]
    public void WhenLoadingRuleSet_ThenConfigFileIsParsed()
    {
        var provider = new FilePath();

        var configs = _repository.Find(provider.GetPath());

        using var scope = new AssertionScope();

        configs.Should().BeOfType<List<QuestionConfig>>();
        configs.Should().HaveCount(4);
    }

    #endregion
}
