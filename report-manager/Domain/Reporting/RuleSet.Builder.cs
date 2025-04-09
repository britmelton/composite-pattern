namespace ReportManager.Domain.Reporting;

public partial class RuleSet
{
    private RuleSet()
    {
    }

    public class Builder : IDepthFirstRuleSetBuilder
    {
        private readonly RuleSet _ruleSet = new();
        private Rule _current;

        public RuleSet GetRuleSet() => _ruleSet;

        public IDepthFirstRuleSetBuilder Add(IDepthFirstRuleSetBuilder.MatchRuleArgs matchRule)
        {
            _current = _current.Add(matchRule);
            return this;
        }

        public IDepthFirstRuleSetBuilder NextQuestion(string questionId)
        {
            _current = _ruleSet.Add(questionId);
            return this;
        }

        public IDepthFirstRuleSetBuilder SelectPrevious()
        {
            _current = _current.Parent;
            return this;
        }
    }
}
