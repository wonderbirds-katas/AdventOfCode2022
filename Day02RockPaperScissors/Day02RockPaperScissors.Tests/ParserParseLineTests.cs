namespace Day02RockPaperScissors.Tests;

public class ParserParseLineTests
{
    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("B X", ShapeScore.Paper)]
    [InlineData("C X", ShapeScore.Scissors)]
    public void OpponentShape(string line, ShapeScore expectedOpponentShape)
    {
        (var actual, var _) = Parser.ParseLine(line);

        Assert.Equal(expectedOpponentShape, actual);
    }

    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("A Y", ShapeScore.Paper)]
    [InlineData("A Z", ShapeScore.Scissors)]
    public void OwnShape(string line, ShapeScore expectedOwnShape)
    {
        (var _, var actual) = Parser.ParseLine(line);

        Assert.Equal(expectedOwnShape, actual);
    }
}