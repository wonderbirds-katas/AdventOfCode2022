namespace Day02RockPaperScissors.Tests;

public class AdviceTests
{
    [Fact]
    public void CalculateRoundToWinAgainstScissors()
    {
        var actual = new Advice(ShapeScore.Scissors, OutcomeScore.Win).CalculateRound();
        Assert.Equal(ShapeScore.Rock, actual.Own);
    }
}