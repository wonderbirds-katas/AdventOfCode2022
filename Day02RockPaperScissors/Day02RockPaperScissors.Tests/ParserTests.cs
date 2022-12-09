namespace Day02RockPaperScissors.Tests;

public class ParserTests
{
    [Fact]
    public void Test()
    {
        (var opponentShape, var ownShape) = Parser.Parse("A X");

        Assert.Equal(ShapeScore.Rock, opponentShape);
        Assert.Equal(ShapeScore.Rock, ownShape);
    }
}