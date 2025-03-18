namespace Report_Manager;

public static class FilePath
{
    public static string RuleSetConfigFile =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"RuleSetConfig.json");
}