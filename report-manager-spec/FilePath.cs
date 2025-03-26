using ReportManager.Infrastructure.Json;

namespace ReportManagerSpec;

public class FilePath : IConfigFileProvider
{
    public string GetPath(string? fileName = null) =>
        Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            fileName ?? "RuleSetConfig.json"
        );
}
