namespace Day02RockPaperScissors.Tests;

public class RoundTests
{
    [Theory]
    [InlineData(ShapeScore.Scissors, OutcomeScore.Win, ShapeScore.Rock, 1 + 6)]
    [InlineData(ShapeScore.Rock, OutcomeScore.Win, ShapeScore.Paper, 2 + 6)]
    [InlineData(ShapeScore.Paper, OutcomeScore.Win, ShapeScore.Scissors, 3 + 6)]
    [InlineData(ShapeScore.Scissors, OutcomeScore.Draw, ShapeScore.Scissors, 3 + 3)]
    [InlineData(ShapeScore.Rock, OutcomeScore.Draw, ShapeScore.Rock, 1 + 3)]
    [InlineData(ShapeScore.Paper, OutcomeScore.Draw, ShapeScore.Paper, 2 + 3)]
    [InlineData(ShapeScore.Scissors, OutcomeScore.Lose, ShapeScore.Paper, 2 + 0)]
    [InlineData(ShapeScore.Rock, OutcomeScore.Lose, ShapeScore.Scissors, 3 + 0)]
    [InlineData(ShapeScore.Paper, OutcomeScore.Lose, ShapeScore.Rock, 1 + 0)]
    public void Score(
        ShapeScore opponent,
        OutcomeScore desiredOutcome,
        ShapeScore expectedOwn,
        int sumScore
    )
    {
        var actual = new Round(opponent, desiredOutcome).Score();
        var expected = new Score(expectedOwn, desiredOutcome);
        Assert.Equal(expected, actual);
        Assert.Equal(sumScore, actual.Sum);
    }
}
