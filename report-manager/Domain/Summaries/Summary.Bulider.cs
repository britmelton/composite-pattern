namespace ReportManager.Domain.Summaries;

public partial class Summary
{
    private readonly Dictionary<string, Rule> _rules = [];

    private Summary()
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
        private readonly Summary _summary = new();
        private Rule? _current;

        public Summary GetSummary() => _summary;

        public IRuleSetBuilder Add(MatchRuleArgs args)
        {
            var matchRule = (MatchRule) args;
            _current = _current.Add(matchRule);
            return this;
        }

        public IRuleSetBuilder NextQuestion(string questionId)
        {
            _current = _summary.Add(questionId);
            return this;
        }

        public IRuleSetBuilder SelectPrevious()
        {
            _current = _current.Parent;
            return this;
        }
    }
}
