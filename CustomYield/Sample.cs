internal static partial class Sample
{
    public static void CustomYield()
    {
        Console.WriteLine("Custom yield:");

        var even = Enumerable.Range(1, 10).MyWhere(x => x % 2 == 0);
        foreach (var e in even)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine();
    }
}