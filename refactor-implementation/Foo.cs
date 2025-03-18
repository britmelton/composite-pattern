namespace Refactor.Implementation;

public class Foo //survey
{
    private readonly decimal[] _values;
    public IReadOnlyList<decimal> Values => _values;

    public Foo(params decimal[] values)
    {
        _values = values;
    }

    //public decimal this[int index] => _values[index];  [indexer]
}
