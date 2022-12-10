namespace Day02RockPaperScissors;

public class Round
{
    public ShapeScore Opponent { get; }

    public ShapeScore Own { get; }

    public Round(ShapeScore opponent, ShapeScore own)
    {
        Opponent = opponent;
        Own = own;
    }

    public Score Score()
    {
        var outcome = CalculateOutcome();

        return new Score(Own, outcome);
    }

    private OutcomeScore CalculateOutcome()
    {
        if (Own.IsGreaterThan(Opponent)) return OutcomeScore.Win;
        if (Own == Opponent) return OutcomeScore.Draw;
        return OutcomeScore.Lose;
    }
}