internal static class ThreadLocal
{
    private static readonly ThreadLocal<int> _value = new(() => 10);

    public static void Run()
    {
        Console.WriteLine($"[ThreadLocal] Main thread start, value {_value.Value}");
        _value.Value = 25;

        new Thread(Work).Start();
        new Thread(Work).Start();

        Console.WriteLine($"[ThreadLocal] Main thread end, value {_value.Value}");
    }

    private static void Work()
    {
        _value.Value++;
        Console.WriteLine($"[ThreadLocal] {Environment.CurrentManagedThreadId} thread, value {_value.Value}");
    }
}