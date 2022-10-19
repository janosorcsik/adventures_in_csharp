static class ThreadStatic
{
    [ThreadStatic]
    private static int value = 10;

    public static void Run()
    {
        Console.WriteLine($"[ThreadStatic] Main thread start, value {value}");
        value = 25;

        new Thread(new ThreadStart(Work)).Start();
        new Thread(new ThreadStart(Work)).Start();

        Console.WriteLine($"[ThreadStatic] Main thread end, value {value}");
    }

    private static void Work()
    {
        value++;
        Console.WriteLine($"[ThreadStatic] {Thread.CurrentThread.ManagedThreadId} thread, value {value}");
    }
}
