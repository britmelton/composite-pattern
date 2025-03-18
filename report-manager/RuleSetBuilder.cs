using Newtonsoft.Json;

namespace Report_Manager;

public class RuleSetBuilder
{
    private List<QuestionConfig> _questionConfigs = new();
    private RuleSet? _ruleSet;

    public RuleSetBuilder Load(List<QuestionConfig> questionConfigs)
    {
        _questionConfigs.Clear();
        _questionConfigs.AddRange(questionConfigs);
        return this;
    }

    public RuleSetBuilder Build()
    {
        _ruleSet = new RuleSet();

        foreach (var q in _questionConfigs)
        {
            var noChangeRule = new NoChangeRule(q.Selections);
            _ruleSet.Add(q.QuestionId, noChangeRule);

            foreach (var r in q.Rules)
            {
                var allRule = new AllRule(r.TargetValue);

                foreach (var mc in r.Conditions)
                    allRule.Add(new MatchRule(mc.QuestionId, mc.Values));

                _ruleSet.Add(q.QuestionId, allRule);
            }
        }

        return this;
    }

    public RuleSet GetRuleSet()
    {
        return _ruleSet!;
    }
}

public interface IQuestionConfigRepository
{
    List<QuestionConfig> Get(string filePath);
}

public class QuestionConfigRepository : IQuestionConfigRepository
{
    public List<QuestionConfig> Get(string filePath)
    {
        return JsonConvert.DeserializeObject<List<QuestionConfig>>(File.ReadAllText(filePath));
    }
}
