using ReportManager.Domain;

namespace ReportManager.Infrastructure.Database;

public class RuleSetRepository : IRuleSetRepository
{
    private readonly List<Rule> _rules;

    public RuleSetRepository(IEnumerable<Rule> rules)
    {
        _rules = rules.ToList();
    }

    public Domain.RuleSet Find(Guid surveyId)
    {
        var ruleSet = new Domain.RuleSet();
        var rules = _rules.Where(x => x.SurveyId == surveyId);

        foreach (var group in rules.GroupBy(x => x.GroupNumber))
        {
            var first = group.First();

            Domain.Rule rule = group.Count() == 1
                ? new MatchRule(
                    first.TargetQuestionId,
                    first.TargetValues.Split(",")
                )
                : new AllRule(
                    first.ReplacementValue,
                    group.Select(
                        x => new MatchRule(
                            x.TargetQuestionId,
                            x.TargetValues.Split(",")
                        )
                    )
                );

            ruleSet.Add(first.QuestionId, rule);
        }

        return ruleSet;
    }
}
