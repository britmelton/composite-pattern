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
        private Rule? _last;

        public Summary GetSummary() => _summary;

        public IRuleSetBuilder Add(MatchRuleArgs args)
        {
            var matchRule = (MatchRule) args;
            _current.Add(_last = matchRule);
            return this;
        }

        public IRuleSetBuilder NextQuestion(string questionId)
        {
            _current = _last = _summary.Add(questionId);
            return this;
        }

        public IRuleSetBuilder SelectLast()
        {
            _current = _last;
            return this;
        }
    }
}
