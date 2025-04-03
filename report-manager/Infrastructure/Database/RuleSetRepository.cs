using ReportManager.Domain.Reporting;

namespace ReportManager.Infrastructure.Database;

public class RuleSetRepository(IDbContext context) : IRuleSetRepository
{
    public Domain.Reporting.RuleSet Find(string path) => throw new NotSupportedException();

    public Domain.Reporting.RuleSet Find(Guid surveyId)
    {
        var ruleSet = new Domain.Reporting.RuleSet();
        var rules = context.Rules.Where(x => x.SurveyId == surveyId);

        foreach (var group in rules.GroupBy(x => x.GroupNumber))
        {
            var first = group.First();

            Domain.Reporting.Rule rule = group.Count() == 1
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
