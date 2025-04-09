namespace ReportManager.Domain.Summaries;

public partial class RuleSetSummary
{
    private readonly Dictionary<string, Rule> _rules = [];

    private RuleSetSummary()
    {
    }

    private Rule Add(string questionId)
    {
        var root = new RootRule();
        _rules.TryAdd(questionId, root);
        return root;
    }

    public class Builder : IRuleSetBuilder
    {
        private readonly RuleSetSummary _ruleSetSummary = new();
        private Rule? _current;

        public RuleSetSummary GetSummary() => _ruleSetSummary;

        public IRuleSetBuilder Add(MatchRuleArgs args)
        {
            var matchRule = (MatchRule) args;
            _current = _current.Add(matchRule);
            return this;
        }

        public IRuleSetBuilder NextQuestion(string questionId)
        {
            _current = _ruleSetSummary.Add(questionId);
            return this;
        }

        public IRuleSetBuilder SelectPrevious()
        {
            _current = _current.Parent;
            return this;
        }
    }
}
