namespace Day02RockPaperScissors;

public static class Round
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        var outcome = CalculateOutcome(opponent, own);

        return new Score(own, outcome);
    }

    private static OutcomeScore CalculateOutcome(ShapeScore opponent, ShapeScore own)
    {
        if (own.IsGreaterThan(opponent)) return OutcomeScore.Win;
        if (own == opponent) return OutcomeScore.Draw;
        return OutcomeScore.Lose;
    }
}
