namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Theory]
    [InlineData(ShapeScore.Rock, ShapeScore.Rock, 1, 3, 1 + 3)]
    [InlineData(ShapeScore.Rock, ShapeScore.Paper, 2, 6, 2 + 6)]
    [InlineData(ShapeScore.Rock, ShapeScore.Scissors, 3, 0, 3 + 0)]
    [InlineData(ShapeScore.Paper, ShapeScore.Rock, 1, 0, 1 + 0)]
    [InlineData(ShapeScore.Paper, ShapeScore.Paper, 2, 3, 2 + 3)]
    [InlineData(ShapeScore.Paper, ShapeScore.Scissors, 3, 6, 3 + 6)]
    [InlineData(ShapeScore.Scissors, ShapeScore.Rock, 1, 6, 1 + 6)]
    [InlineData(ShapeScore.Scissors, ShapeScore.Paper, 2, 0, 2 + 0)]
    [InlineData(ShapeScore.Scissors, ShapeScore.Scissors, 3, 3, 3 + 3)]
    public void OpponentVsOwnShapes(ShapeScore opponent, ShapeScore own, int shapeScore, int outcomeScore, int sumScore)
    {
        var actual = Turn.Score(opponent, own);
        var expected = new Score((ShapeScore) shapeScore, (OutcomeScore)outcomeScore);
        Assert.Equal(expected, actual);
        Assert.Equal(sumScore, actual.Sum);
    }
}