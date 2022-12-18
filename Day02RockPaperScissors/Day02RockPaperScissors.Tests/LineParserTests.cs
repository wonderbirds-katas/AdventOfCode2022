namespace Day02RockPaperScissors.Tests;

public class LineParserTests
{
    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("B X", ShapeScore.Paper)]
    [InlineData("C X", ShapeScore.Scissors)]
    public void OpponentShape2(string line, ShapeScore expectedOpponentShape)
    {
        var actual = line.Parse();

        Assert.Equal(expectedOpponentShape, actual.Opponent);
    }

    [Theory]
    [InlineData("A X", OutcomeScore.Lose)]
    [InlineData("A Y", OutcomeScore.Draw)]
    [InlineData("A Z", OutcomeScore.Win)]
    public void DesiredOutcome(string line, OutcomeScore expectedOutcome)
    {
        var actual = line.Parse();

        Assert.Equal(expectedOutcome, actual.DesiredOutcome);
    }

    [Fact]
    public void InvalidOpponentShapeLiteral()
    {
        const char invalidShapeLiteral = 'I';
        var invalidLine = $"{invalidShapeLiteral} X";

        var exception = Assert.Throws<InvalidShapeLiteralException>(() => invalidLine.Parse());
        Assert.EndsWith($"'{invalidShapeLiteral}'", exception.Message);
    }

    [Fact]
    public void InvalidDesiredOutcomeLiteral()
    {
        const char invalidShapeLiteral = 'I';
        var invalidLine = $"A {invalidShapeLiteral}";

        var exception = Assert.Throws<InvalidShapeLiteralException>(() => invalidLine.Parse());
        Assert.EndsWith($"'{invalidShapeLiteral}'", exception.Message);
    }
}
