using BenchmarkDotNet.Running;

namespace Task1.Tests;

public class GameBenchmarkTest
{
    [Fact, Trait("Category", "Benchmark")]
    public void getScore_Benchmark()
    {
        var summary = BenchmarkRunner.Run<GetScoreBenchmarkScenarios>();
        Assert.All(summary.Reports, report => Assert.True(report.ResultStatistics!.Median < 100000));
    }
}