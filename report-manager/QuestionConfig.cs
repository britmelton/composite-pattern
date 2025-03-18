using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Report_Manager;

public class QuestionConfig
{
    public string QuestionId { get; set; }
    public string[] Selections { get; set; }
    public QuestionCalculatedValues[] Rules { get; set; }
    public ModifyValue ModifyValue { get; set; }
    public bool IsDeleted { get; set; }
}

public class QuestionCalculatedValues
{
    public string TargetValue { get; set; }
    public QuestionWithValuesToMatch[] Conditions { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public MatchType MatchType { get; set; }
}

public class QuestionWithValuesToMatch
{
    public string QuestionId { get; set; }
    public string[] Values { get; set; }
}

public class ModifyValue
{
    public string[] Values { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public ModifyOperationType ModifyType { get; set; }
    public int ModifyAmount { get; set; }
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


