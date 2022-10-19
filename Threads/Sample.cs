static partial class Sample
{
    public static void Threads()
    {
        ThreadStatic.Run();
        ThreadLocal.Run();
        Static.Run();
    }
}
