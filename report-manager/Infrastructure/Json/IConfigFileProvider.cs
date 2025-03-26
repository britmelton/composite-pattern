namespace ReportManager.Infrastructure.Json;

public interface IConfigFileProvider
{
    string GetPath(string? fileName = null);
}
