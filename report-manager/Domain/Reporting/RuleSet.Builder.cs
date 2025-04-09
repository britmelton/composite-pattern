namespace ReportManager.Domain.Reporting;

public partial class RuleSet
{
    private RuleSet()
    {
    }

    public class Builder : IRuleSetBuilder
    {
        private readonly RuleSet _ruleSet = new();
        private Rule _current;

        public RuleSet GetRuleSet() => _ruleSet;

        public IRuleSetBuilder Add(MatchRuleArgs matchRule)
        {
            _current = _current.Add(matchRule);
            return this;
        }

        public IRuleSetBuilder NextQuestion(string questionId)
        {
            _current = _ruleSet.Add(questionId);
            return this;
        }

        public IRuleSetBuilder SelectPrevious()
        {
            _current = _current.Parent;
            return this;
        }
    }
}
