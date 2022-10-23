internal static partial class Sample
{
    public static void Mocking()
    {
        Console.WriteLine("Mock:");

        var mock = new Mock<ITest>().Set(x => x.DoSomething(), typeof(Test)).Build();

        mock.DoSomething();

        Console.WriteLine();
    }
}

public interface ITest
{
    public void DoSomething();
}

public class Test
{
    public void DoSomething()
    {
        Console.WriteLine("From Test class.");
    }
}