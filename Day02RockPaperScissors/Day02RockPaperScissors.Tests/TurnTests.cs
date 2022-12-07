using static Day02RockPaperScissors.Outcome;

namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Theory]
    [InlineData(Shape.Rock, Shape.Rock, ShapeScore.Rock, Draw, (int)ShapeScore.Rock + (int)OutcomeScore.Draw)]
    [InlineData(Shape.Rock, Shape.Paper, ShapeScore.Paper, Win, (int)ShapeScore.Paper + (int)OutcomeScore.Win)]
    public void OpponentVsOwnShapes(Shape opponent, Shape own, ShapeScore shapeScore, Outcome outcome, int sumScore)
    {
        var actual = Turn.Score(opponent, own);
        var expected = new Score((int) shapeScore, outcome);
        Assert.Equal(expected, actual);
        Assert.Equal(sumScore, actual.Sum);
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