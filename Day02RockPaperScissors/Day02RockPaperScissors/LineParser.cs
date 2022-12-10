namespace Day02RockPaperScissors;

public static class LineParserExtensions
{
    public static Advice ParsePart2(this string line)
    {
        return new Advice(ShapeScore.Rock, OutcomeScore.Lose);
    }
    
    public static Round Parse(this string line)
    {
        var opponentShape = ParseOpponentShape(line);
        var ownShape = ParseOwnShape(line);

        return new Round(opponentShape, ownShape);
    }

    private static ShapeScore ParseOpponentShape(string line)
    {
        var opponentShapeLiteral = line[0];
        return opponentShapeLiteral switch
        {
            'A' => ShapeScore.Rock,
            'B' => ShapeScore.Paper,
            'C' => ShapeScore.Scissors,
            _ => throw new InvalidShapeLiteralException(opponentShapeLiteral)
        };
    }

    private static ShapeScore ParseOwnShape(string line)
    {
        var ownShapeLiteral = line[2];
        return ownShapeLiteral switch
        {
            'X' => ShapeScore.Rock,
            'Y' => ShapeScore.Paper,
            'Z' => ShapeScore.Scissors,
            _ => throw new InvalidShapeLiteralException(ownShapeLiteral)
        };
    }
}