namespace Task1.Tests;

public class GameTestCasesGenerator
{
    private readonly int _stampsCount;
    public static readonly Score ScoreForValidate = new(1, 1);
    private static readonly Game EmptyGame = new();
    public readonly Game TestGame;

    public enum CaseCategory
    {
        Valid,
        InvalidArgument
    }

    public record Case(object[] Data, CaseCategory Category);

    public GameTestCasesGenerator(int stampsCount)
    {
        _stampsCount = stampsCount;
        TestGame = new Game(GenerateStamps(_stampsCount));
    }

    public IEnumerable<Case> GenerateTestCases()
    {
        var cases = new List<Case>();
        cases.Add(new Case(new object[] {TestGame, -1}, CaseCategory.InvalidArgument));
        cases.Add(new Case(new object[] {GenerateGameWithValidScore(0), 0}, CaseCategory.Valid));
        if (_stampsCount > 1)
        {
            cases.Add(new Case(new object[] {GenerateGameWithValidScore(1), 1}, CaseCategory.Valid));
            cases.Add(new Case(new object[] {GenerateGameWithValidScore(_stampsCount - 2), _stampsCount - 2},
                CaseCategory.Valid));
            cases.Add(new Case(new object[] {GenerateGameWithValidScore(_stampsCount - 1), _stampsCount - 1},
                _stampsCount == 0 ? CaseCategory.InvalidArgument : CaseCategory.Valid));
        }

        cases.Add(new Case(new object[] {TestGame, _stampsCount}, CaseCategory.InvalidArgument));
        if (_stampsCount != int.MaxValue)
        {
            cases.Add(new Case(new object[] {TestGame, int.MaxValue}, CaseCategory.InvalidArgument));
        }
        cases.Add(new Case(new object[] {TestGame, int.MinValue}, CaseCategory.InvalidArgument));
        cases.Add(new Case(new object[] {EmptyGame, 0}, CaseCategory.InvalidArgument));
        return cases;
    }

    private Game GenerateGameWithValidScore(int scorePosition) =>
        new(GenerateStamps(_stampsCount, scorePosition));

    private static GameStamp[] GenerateStamps(int stampsCount)
    {
        if (stampsCount == 0)
        {
            throw new ArgumentException();
        }

        var data = new GameStamp[stampsCount];
        data[0] = new GameStamp(0, 0, 0);
        for (var i = 1; i < stampsCount; i++)
        {
            data[i] = new GameStamp(
                data[i - 1].offset + 1,
                0,
                0
            );
        }

        return data;
    }

    private static GameStamp[] GenerateStamps(int stampsCount, int scorePosition)
    {
        var data = GenerateStamps(stampsCount);
        data[scorePosition] = new GameStamp(
            data[scorePosition].offset,
            ScoreForValidate.home,
            ScoreForValidate.away
        );

        return data;
    }
}