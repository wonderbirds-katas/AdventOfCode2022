namespace Day02RockPaperScissors.Tests;

public class ParserParseLineTests
{
    [Fact]
    public void RockVsRock()
    {
        (var opponentShape, var ownShape) = Parser.ParseLine("A X");

        Assert.Equal(ShapeScore.Rock, opponentShape);
        Assert.Equal(ShapeScore.Rock, ownShape);
    }
}