namespace ReportManager.Infrastructure.Database;

public interface IDbContext
{
    public IEnumerable<Rule> Rules { get; }
}
