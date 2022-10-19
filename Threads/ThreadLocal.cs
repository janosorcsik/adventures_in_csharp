static class ThreadLocal
{
    private static ThreadLocal<int> value = new ThreadLocal<int>(() => 10);

    public static void Run()
    {
        Console.WriteLine($"[ThreadLocal] Main thread start, value {value.Value}");
        value.Value = 25;

        new Thread(new ThreadStart(Work)).Start();
        new Thread(new ThreadStart(Work)).Start();

        Console.WriteLine($"[ThreadLocal] Main thread end, value {value.Value}");
    }

    static void Work()
    {
        value.Value++;
        Console.WriteLine($"[ThreadLocal] {Thread.CurrentThread.ManagedThreadId} thread, value {value.Value}");
    }
}
