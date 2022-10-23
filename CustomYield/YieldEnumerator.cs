using System.Collections;

internal class YieldEnumerator<T> : IEnumerator<T>
{
    private readonly IEnumerator<T> _enumerator;
    private readonly Func<T, bool> _predicate;

    public YieldEnumerator(IEnumerator<T> enumerator, Func<T, bool> predicate)
    {
        _enumerator = enumerator;
        _predicate = predicate;
    }

    public T Current { get; private set; } = default!;

    object IEnumerator.Current => Current!;

    public bool MoveNext()
    {
        while (_enumerator.MoveNext())
        {
            var c = _enumerator.Current;

            if (c is null || !_predicate(c))
            {
                continue;
            }

            Current = c;

            return true;
        }

        return false;
    }

    public void Dispose()
    {
        _enumerator.Dispose();
    }

    public void Reset()
    {
        _enumerator.Reset();
    }
}