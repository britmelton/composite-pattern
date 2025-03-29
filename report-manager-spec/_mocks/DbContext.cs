using ReportManager.Infrastructure.Database;
using Rule = ReportManager.Infrastructure.Database.Rule;

namespace ReportManagerSpec;

public class DbContext(IEnumerable<Rule> rules) : IDbContext
{
    private readonly List<Rule> _rules = rules.ToList();

    public IEnumerable<Rule> Rules => _rules;
}
