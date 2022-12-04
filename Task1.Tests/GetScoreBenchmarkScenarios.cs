using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Task1.Tests;

[SimpleJob(RuntimeMoniker.Net60)]
public class GetScoreBenchmarkScenarios
{
    private Game _game;
    private readonly Random _random = new ();
    [Params(1000, 10000, 100000, 1000000)] 
    public int gameLength;
    
    [GlobalSetup]
    public void Setup()
    {
        _game = new GameTestCasesGenerator(gameLength).TestGame;
    }
    [Benchmark]
    public void getScore()
    {
        _game.getScore(_random.Next(gameLength-1));
    }
}