internal static class Static
{
    private static int _value = 10;

    public static void Run()
    {
        Console.WriteLine($"[Static] Main thread start, value {_value}");
        _value = 25;

        new Thread(Work).Start();
        new Thread(Work).Start();

        Console.WriteLine($"[Static] Main thread end, value {_value}");
    }

    private static void Work()
    {
        _value++;
        Console.WriteLine($"[Static] {Environment.CurrentManagedThreadId} thread, value {_value}");
    }
}