namespace Day02RockPaperScissors.Tests;

public class TurnTests
{
    [Theory]
    [InlineData(Day02RockPaperScissors.ShapeScore.Rock, Day02RockPaperScissors.ShapeScore.Rock, ShapeScore.Rock, OutcomeScore.Draw, (int)ShapeScore.Rock + (int)OutcomeScore.Draw)]
    [InlineData(Day02RockPaperScissors.ShapeScore.Rock, Day02RockPaperScissors.ShapeScore.Paper, ShapeScore.Paper, OutcomeScore.Win, (int)ShapeScore.Paper + (int)OutcomeScore.Win)]
    [InlineData(Day02RockPaperScissors.ShapeScore.Rock, Day02RockPaperScissors.ShapeScore.Scissors, ShapeScore.Scissors, OutcomeScore.Win, (int)ShapeScore.Scissors + (int)OutcomeScore.Win)]
    [InlineData(Day02RockPaperScissors.ShapeScore.Paper, Day02RockPaperScissors.ShapeScore.Rock, ShapeScore.Rock, OutcomeScore.Lose, (int)ShapeScore.Rock + (int)OutcomeScore.Lose)]
    public void OpponentVsOwnShapes(Day02RockPaperScissors.ShapeScore opponent, Day02RockPaperScissors.ShapeScore own, ShapeScore shapeScore, OutcomeScore outcomeScore, int sumScore)
    {
        var actual = Turn.Score(opponent, own);
        var expected = new Score((Day02RockPaperScissors.ShapeScore) shapeScore, (Day02RockPaperScissors.OutcomeScore)outcomeScore);
        Assert.Equal(expected, actual);
        Assert.Equal(sumScore, actual.Sum);
    }

    public enum ShapeScore
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    public enum OutcomeScore
    {
        Lose = 0,
        Draw = 3,
        Win = 6,
    }
}