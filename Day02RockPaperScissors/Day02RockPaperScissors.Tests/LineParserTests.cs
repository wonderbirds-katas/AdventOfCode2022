namespace Day02RockPaperScissors.Tests;

public class LineParserTests
{
    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("B X", ShapeScore.Paper)]
    [InlineData("C X", ShapeScore.Scissors)]
    public void OpponentShape(string line, ShapeScore expectedOpponentShape)
    {
        (var actual, var _) = LineParser.ParseLine(line);

        Assert.Equal(expectedOpponentShape, actual);
    }

    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("A Y", ShapeScore.Paper)]
    [InlineData("A Z", ShapeScore.Scissors)]
    public void OwnShape(string line, ShapeScore expectedOwnShape)
    {
        (var _, var actual) = LineParser.ParseLine(line);

        Assert.Equal(expectedOwnShape, actual);
    }
}