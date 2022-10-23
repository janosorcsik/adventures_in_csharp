using System.Collections;

class YieldEnumerator<T> : IEnumerator<T>
{
    private IEnumerator<T> enumerator;
    private Func<T, bool> predicate;
    private T current;

    public T Current => current;
    object IEnumerator.Current => current;

    public YieldEnumerator(IEnumerator<T> enumerator, Func<T, bool> predicate)
    {
        this.enumerator = enumerator;
        this.predicate = predicate;
    }


    public bool MoveNext()
    {
        while (enumerator.MoveNext())
        {
            var c = enumerator.Current;

            if (predicate(c))
            {
                current = c;

                return true;
            }
        }
        return false;
    }

    public void Dispose() => enumerator.Dispose();
    public void Reset() => enumerator.Reset();
}
