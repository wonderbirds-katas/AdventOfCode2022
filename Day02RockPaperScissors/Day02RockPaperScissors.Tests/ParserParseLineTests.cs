namespace Day02RockPaperScissors.Tests;

public class ParserParseLineTests
{
    [Theory]
    [InlineData("A X", ShapeScore.Rock, ShapeScore.Rock)]
    public void RockVsRock(string line, ShapeScore expectedOpponentShape, ShapeScore expectedOwnShape)
    {
        (var opponentShape, var ownShape) = Parser.ParseLine(line);

        Assert.Equal(expectedOpponentShape, opponentShape);
        Assert.Equal(expectedOwnShape, ownShape);
    }
}