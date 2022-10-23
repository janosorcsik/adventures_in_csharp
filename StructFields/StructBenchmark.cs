using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StructBenchmark
{
    private static int Sum1(Struct1 s)
    {
        return s.Number1;
    }

    private static int Sum2(Struct2 s)
    {
        return s.Number1 + s.Number2;
    }

    private static int Sum3(Struct3 s)
    {
        return s.Number1 + s.Number2 + s.Number3;
    }

    private static int Sum4(Struct4 s)
    {
        return s.Number1 + s.Number2 + s.Number3 + s.Number4;
    }

    private static int Sum5(Struct5 s)
    {
        return s.Number1 + s.Number2 + s.Number3 + s.Number4 + s.Number5;
    }

    private static int Sum6(Struct6 s)
    {
        return s.Number1 + s.Number2 + s.Number3 + s.Number4 + s.Number5 + s.Number6;
    }

    private static int Sum7(Struct7 s)
    {
        return s.Number1 + s.Number2 + s.Number3 + s.Number4 + s.Number5 + s.Number6 + s.Number7;
    }

    private static int Sum8(Struct8 s)
    {
        return s.Number1 + s.Number2 + s.Number3 + s.Number4 + s.Number5 + s.Number6 + s.Number7 + s.Number8;
    }
#pragma warning disable CA1822
    [Benchmark]
    public int Fields1()
    {
        var s = new Struct1(0);
        return Sum1(s);
    }

    [Benchmark]
    public int Fields2()
    {
        var s = new Struct2();
        return Sum2(s);
    }

    [Benchmark]
    public int Fields3()
    {
        var s = new Struct3();
        return Sum3(s);
    }

    [Benchmark]
    public int Fields4()
    {
        var s = new Struct4();
        return Sum4(s);
    }

    [Benchmark]
    public int Fields5()
    {
        var s = new Struct5();
        return Sum5(s);
    }

    [Benchmark]
    public int Fields6()
    {
        var s = new Struct6();
        return Sum6(s);
    }

    [Benchmark]
    public int Fields7()
    {
        var s = new Struct7();
        return Sum7(s);
    }

    [Benchmark]
    public int Fields8()
    {
        var s = new Struct8();
        return Sum8(s);
    }
#pragma warning restore CA1822
}