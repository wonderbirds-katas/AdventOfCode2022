namespace Day02RockPaperScissors.Tests;

public class LineParserTests
{
    [Theory]
    [InlineData("A X", OutcomeScore.Lose)]
    public void DesiredOutcome(string line, OutcomeScore expectedOutcome)
    {
        var actual = line.ParsePart2();
        Assert.Equal(expectedOutcome, actual.DesiredOutcome);
    }
    
    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("B X", ShapeScore.Paper)]
    [InlineData("C X", ShapeScore.Scissors)]
    public void OpponentShape(string line, ShapeScore expectedOpponentShape)
    {
        var actual = line.Parse();

        Assert.Equal(expectedOpponentShape, actual.Opponent);
    }

    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("A Y", ShapeScore.Paper)]
    [InlineData("A Z", ShapeScore.Scissors)]
    public void OwnShape(string line, ShapeScore expectedOwnShape)
    {
        var actual = line.Parse();

        Assert.Equal(expectedOwnShape, actual.Own);
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
    public void InvalidOwnShapeLiteral()
    {
        const char invalidShapeLiteral = 'I';
        var invalidLine = $"A {invalidShapeLiteral}";
        
        var exception = Assert.Throws<InvalidShapeLiteralException>(() => invalidLine.Parse());
        Assert.EndsWith($"'{invalidShapeLiteral}'", exception.Message);
    }

}