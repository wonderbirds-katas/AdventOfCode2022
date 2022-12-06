namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Fact]
    public void RockVsRock()
    {
        var opponent = Shape.Rock;
        var own = Shape.Rock;
        var actual = Turn.Score(opponent, own);
        Assert.Equal(4, actual);
    }
}

public static class Turn
{
    public static int Score(Shape opponent, Shape own)
    {
        return 4;
    }
}

public enum Shape
{
    Rock
}
