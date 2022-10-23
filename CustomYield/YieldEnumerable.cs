using System.Collections;

internal class YieldEnumerable<T> : IEnumerable<T>
{
    private readonly IEnumerator<T> _enumerator;
    private readonly Func<T, bool> _predicate;

    public YieldEnumerable(IEnumerable<T> items, Func<T, bool> predicate)
    {
        _enumerator = items.GetEnumerator();
        _predicate = predicate;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new YieldEnumerator<T>(_enumerator, _predicate);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}