using ReportManager.Domain;

namespace ReportManager.Infrastructure.Json;

public class RuleSetRepository
{
    private readonly List<QuestionConfig> _questionConfigs = [];
    private RuleSet? _ruleSet;

    public RuleSetRepository Build()
    {
        _ruleSet = new RuleSet();

        foreach (var q in _questionConfigs)
        {
            _ruleSet.Add(q.QuestionId, new MatchRule(q.QuestionId, q.Selections));

            foreach (var r in q.Rules)
            {
                var allRule = new AllRule(
                    r.TargetValue,
                    r.Conditions.Select(x => new MatchRule(x.QuestionId, x.Values))
                );

                _ruleSet.Add(q.QuestionId, allRule);
            }
        }

        return this;
    }

    public RuleSet GetRuleSet() => _ruleSet!;

    public RuleSetRepository Load(List<QuestionConfig> questionConfigs)
    {
        _questionConfigs.Clear();
        _questionConfigs.AddRange(questionConfigs);
        return this;
    }
}
