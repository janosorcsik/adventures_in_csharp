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

    public T Current { get; private set; }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        while (_enumerator.MoveNext())
        {
            var c = _enumerator.Current;

            if (_predicate(c))
            {
                Current = c;

                return true;
            }
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