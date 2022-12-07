namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Theory]
    [InlineData(Shape.Rock, Shape.Rock, ShapeScore.Rock, OutcomeScore.Draw)]
    [InlineData(Shape.Rock, Shape.Paper, ShapeScore.Paper, OutcomeScore.Win)]
    public void OpponentVsOwnShapes(Shape opponent, Shape own, ShapeScore shapeScore, OutcomeScore outcomeScore)
    {
        var actual = Turn.Score(opponent, own);
        var expected = (int) shapeScore + (int) outcomeScore;
        Assert.Equal(expected, actual.Sum);
    }

    public enum ShapeScore
    {
        Rock = 1,
        Paper = 2,
    }

    public enum OutcomeScore
    {
        Draw = 3,
        Win = 6,
    }
}