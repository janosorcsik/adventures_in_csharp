using System.Collections;

class YieldEnumerable<T> : IEnumerable<T>
{
    private IEnumerator<T> enumerator;
    private Func<T, bool> predicate;

    public YieldEnumerable(IEnumerable<T> items, Func<T, bool> predicate)
    {
        enumerator = items.GetEnumerator();
        this.predicate = predicate;
    }

    public IEnumerator<T> GetEnumerator() => new YieldEnumerator<T>(enumerator, predicate);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
