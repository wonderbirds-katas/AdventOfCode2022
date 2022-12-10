namespace Day02RockPaperScissors;

public static class Turn
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        var outcome = CalculateOutcome(opponent, own);

        return new Score(own, outcome);
    }

    private static OutcomeScore CalculateOutcome(ShapeScore opponent, ShapeScore own)
    {
        var greaterThan = new Dictionary<ShapeScore, ShapeScore>
        {
            [ShapeScore.Rock] = ShapeScore.Paper,
            [ShapeScore.Paper] = ShapeScore.Scissors,
            [ShapeScore.Scissors] = ShapeScore.Rock
        };

        if (own == greaterThan[opponent]) return OutcomeScore.Win;
        if (own == opponent) return OutcomeScore.Draw;
        return OutcomeScore.Lose;
    }
}
