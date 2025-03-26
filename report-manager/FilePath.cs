namespace ReportManager;

public static class FilePath
{
    public static string RuleSetConfigFile =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"RuleSetConfig.json");
}
