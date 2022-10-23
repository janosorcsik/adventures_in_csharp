internal static class Extensions
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        return new YieldEnumerable<T>(items, predicate);
    }
}