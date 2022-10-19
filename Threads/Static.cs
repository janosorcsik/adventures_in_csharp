static class Static
{
    private static int value = 10;

    public static void Run()
    {
        Console.WriteLine($"[Static] Main thread start, value {value}");
        value = 25;

        new Thread(new ThreadStart(Work)).Start();
        new Thread(new ThreadStart(Work)).Start();

        Console.WriteLine($"[Static] Main thread end, value {value}");
    }

    static void Work()
    {
        value++;
        Console.WriteLine($"[Static] {Thread.CurrentThread.ManagedThreadId} thread, value {value}");
    }
}
