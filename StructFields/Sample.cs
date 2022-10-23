using BenchmarkDotNet.Running;

internal static partial class Sample
{
    public static void StructFields()
    {
        BenchmarkRunner.Run<StructBenchmark>();
    }
}