using ReportManager.Json;

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
        var configs = _repository.Find(FilePath.RuleSetConfigFile);

        configs.Should().BeOfType<List<QuestionConfig>>();
    }

    #endregion
}
