namespace Day02RockPaperScissors.Tests;

public class AdviceTests
{
    [Theory]
    [InlineData(ShapeScore.Scissors, OutcomeScore.Win, ShapeScore.Rock)]
    [InlineData(ShapeScore.Rock, OutcomeScore.Win, ShapeScore.Paper)]
    [InlineData(ShapeScore.Paper, OutcomeScore.Win, ShapeScore.Scissors)]
    public void CalculateRound(ShapeScore opponent, OutcomeScore desiredOutcome, ShapeScore expected)
    {
        var actual = new Advice(opponent, desiredOutcome).CalculateRound();
        Assert.Equal(expected, actual.Own);
    }
}