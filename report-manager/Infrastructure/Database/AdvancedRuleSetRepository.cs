using ReportManager.Domain;

namespace ReportManager.Infrastructure.Database;

public class AdvancedRuleSetRepository(IDbContext context) : IAdvancedRuleSetRepository
{
    private IDepthFirstRuleSetBuilder _builder;

    public IAdvancedRuleSetRepository Find(Guid surveyId)
    {
        var configuredQuestions = new List<string>();
        var groupNumber = -1;

        foreach (var rule in context.Rules.Where(x => x.SurveyId == surveyId))
        {
            var questionId = rule.QuestionId;

            if (!configuredQuestions.Contains(questionId))
            {
                configuredQuestions.Add(questionId);
                _builder.NextQuestion(questionId);
                groupNumber = -1;
            }

            if (groupNumber != -1 && rule.GroupNumber != groupNumber)
                _builder.SelectPrevious();

            groupNumber = rule.GroupNumber;

            _builder.Add(new(questionId, rule.TargetQuestionId, rule.TargetValues.Split(","), rule.ReplacementValue));
        }

        return this;
    }

    public IAdvancedRuleSetRepository Find(string path) => throw new NotSupportedException();

    public IAdvancedRuleSetRepository With(IDepthFirstRuleSetBuilder builder)
    {
        _builder = builder;
        return this;
    }
}
