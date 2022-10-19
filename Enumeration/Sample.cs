static partial class Sample
{
    public static void Enumeration()
    {
        var even = Enumerable.Range(1, 10).MyWhere(x => x % 2 == 0);
        foreach (var e in even)
        {
            Console.WriteLine(e);
        }
    }
}
