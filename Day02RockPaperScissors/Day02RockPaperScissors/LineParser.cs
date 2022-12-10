namespace Day02RockPaperScissors;

public static class LineParserExtensions
{
    public static Advice Parse(this string line)
    {
        var desiredOutcome = ParseDesiredOutcome(line);
        var opponentShape = ParseOpponentShape(line);
        
        return new Advice(opponentShape, desiredOutcome);
    }

    private static OutcomeScore ParseDesiredOutcome(string line)
    {
        var desiredOutcomeLiteral = line[2];
        var desiredOutcome = desiredOutcomeLiteral switch
        {
            'X' => OutcomeScore.Lose,
            'Y' => OutcomeScore.Draw,
            'Z' => OutcomeScore.Win,
            _ => throw new InvalidShapeLiteralException(desiredOutcomeLiteral)
        };
        return desiredOutcome;
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
}