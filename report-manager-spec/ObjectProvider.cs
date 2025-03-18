using Report_Manager;

namespace Report_Manager_Spec;

public class ObjectProvider
{
    public static List<QuestionConfig> GetMatchRules()
    {
        var distribWeb = new QuestionWithValuesToMatch();
        distribWeb.QuestionId = "DISTRIB";
        distribWeb.Values = ["2"];

        var responseIsNull = new QuestionWithValuesToMatch();
        responseIsNull.QuestionId = "Q1";
        responseIsNull.Values = [ "null" ];

        var calculatedValues = new QuestionCalculatedValues();
        calculatedValues.TargetValue = "99";
        calculatedValues.Conditions = [responseIsNull, distribWeb];
        calculatedValues.MatchType = Report_Manager.MatchType.MatchAll;

        var questionConfig = new QuestionConfig()
        {
            QuestionId = "Q1",
            Selections = ["1", "2", "98", "99"],
            Rules = [calculatedValues]
        };

        return new List<QuestionConfig>() { questionConfig };
    }
}