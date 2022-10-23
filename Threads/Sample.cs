internal static partial class Sample
{
    public static void Threads()
    {
        Console.WriteLine("Threads:");

        Static.Run();
        ThreadStatic.Run();
        ThreadLocal.Run();
    }
}