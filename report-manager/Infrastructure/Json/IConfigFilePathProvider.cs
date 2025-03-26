namespace ReportManager.Infrastructure.Json;

public interface IConfigFilePathProvider
{
    string GetPath(string? fileName = null);
}
