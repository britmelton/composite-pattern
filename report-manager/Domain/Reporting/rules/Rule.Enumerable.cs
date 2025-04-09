using System.Collections;

namespace ReportManager.Domain.Reporting;

public partial class Rule : IEnumerable<Rule>
{
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _children).GetEnumerator();

    public IEnumerator<Rule> GetEnumerator() => _children.GetEnumerator();
}
