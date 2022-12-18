namespace Day02RockPaperScissors;

public enum ShapeScore
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public static class ShapeSourceExtensions
{
    public static bool IsGreaterThan(this ShapeScore self, ShapeScore other)
    {
        var greaterThan = new Dictionary<ShapeScore, ShapeScore>
        {
            [ShapeScore.Rock] = ShapeScore.Paper,
            [ShapeScore.Paper] = ShapeScore.Scissors,
            [ShapeScore.Scissors] = ShapeScore.Rock
        };

        return self == greaterThan[other];
    }
}
