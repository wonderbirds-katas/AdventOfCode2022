namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Theory]
    [InlineData(Shape.Rock, Shape.Rock, ShapeScore.Rock, OutcomeScore.Draw)]
    public void OpponentVsOwnShapes(Shape opponent, Shape own, ShapeScore shapeScore, OutcomeScore outcomeScore)
    {
        var actual = Turn.Score(opponent, own);
        var expected = (int) shapeScore + (int) outcomeScore;
        Assert.Equal(expected, actual);
    }

    public enum ShapeScore
    {
        Rock = 1
    }

    public enum OutcomeScore
    {
        Draw = 3
    }
}