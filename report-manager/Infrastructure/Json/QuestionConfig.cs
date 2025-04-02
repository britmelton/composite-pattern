using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ReportManager.Infrastructure.Json;

/// <remarks>A storage implementation detail.</remarks>
public partial class QuestionConfig
{
    public string QuestionId { get; set; }
    public bool IsDeleted { get; set; }
    public ModifyValue ModifyValue { get; set; }
    public QuestionCalculatedValues[] Rules { get; set; }
    public string[] Selections { get; set; }
}

public class QuestionCalculatedValues
{
    public QuestionWithValuesToMatch[] Conditions { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public MatchType MatchType { get; set; }

    public string TargetValue { get; set; } // replacement
}

public class QuestionWithValuesToMatch
{
    public string QuestionId { get; set; }
    public string[] Values { get; set; }
}

public class ModifyValue
{
    public int ModifyAmount { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ModifyOperationType ModifyType { get; set; }

    public string[] Values { get; set; }
}

public enum MatchType
{
    MatchAny,
    MatchAll
}

public enum ModifyOperationType
{
    Subtract,
    Update
}
