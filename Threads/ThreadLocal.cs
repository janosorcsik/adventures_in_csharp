internal static class ThreadLocal
{
    private static readonly ThreadLocal<int> Value = new(() => 10);

    public static void Run()
    {
        Console.WriteLine($"[ThreadLocal] Main thread start, value {Value.Value}");
        Value.Value = 25;

        new Thread(Work).Start();
        new Thread(Work).Start();

        Console.WriteLine($"[ThreadLocal] Main thread end, value {Value.Value}");
    }

    private static void Work()
    {
        Value.Value++;
        Console.WriteLine($"[ThreadLocal] {Environment.CurrentManagedThreadId} thread, value {Value.Value}");
    }
}