using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec;

public class TestFilePathProvider : IConfigFilePathProvider
{
    public string GetPath(string? fileName = null) =>
        Path.Combine(
            $"{AppDomain.CurrentDomain.BaseDirectory}/local",
            fileName ?? "RuleSetConfig.json"
        );
}
