namespace Day02RockPaperScissors;

public static class LineParserExtensions
{
    public static Round ParseShapes(this string line)
    {
        var opponentShapeLiteral = line[0];
        var opponentShape = opponentShapeLiteral switch
        {
            'A' => ShapeScore.Rock,
            'B' => ShapeScore.Paper,
            'C' => ShapeScore.Scissors,
            _ => throw new InvalidShapeLiteralException(opponentShapeLiteral)
        };

        var ownShapeLiteral = line[2];
        var ownShape = ownShapeLiteral switch
        {
            'X' => ShapeScore.Rock,
            'Y' => ShapeScore.Paper,
            'Z' => ShapeScore.Scissors,
            _ => throw new InvalidShapeLiteralException(ownShapeLiteral)
        };

        return new Round(opponentShape, ownShape);
    }
}