using static Task1.Tests.GameTestCasesGenerator;

namespace Task1.Tests;

public class GameTests
{
    private static readonly IEnumerable<Case> Cases;
    
    static GameTests()
    {
        Cases = new GameTestCasesGenerator(100).GenerateTestCases();
    }

    [Theory]
    [MemberData(nameof(GetValidData))]
    public void getScore_CheckValid(Game game, int offset)
    {
        var score = game.getScore(offset);
        Assert.Equal(score, ScoreForValidate);
    }

    [Theory]
    [MemberData(nameof(GetInvalidArgumentData))]
    public void getScore_CheckInvalidArgument(Game game, int offset)
    {
        Assert.ThrowsAny<ArgumentException>(() => game.getScore(offset));
    }

    public static IEnumerable<object[]> GetValidData() =>
        Cases.Where(c => c.Category == CaseCategory.Valid).Select(c => c.Data);

    public static IEnumerable<object[]> GetInvalidArgumentData() =>
        Cases.Where(c => c.Category == CaseCategory.InvalidArgument).Select(c => c.Data);
}