using ReportManager.Json;

namespace ReportManagerSpec;

public class RuleSetConfigSpec
{
    #region Setup

    private readonly QuestionConfigRepository _questionConfigRepo = new();

    #endregion

    #region Requirements

    [Fact]
    public void WhenLoadingRuleSet_ThenConfigFileIsParsed()
    {
        var configs = _questionConfigRepo.Get(FilePath.RuleSetConfigFile);

        configs.Should().BeOfType<List<QuestionConfig>>();
    }

    #endregion
}
