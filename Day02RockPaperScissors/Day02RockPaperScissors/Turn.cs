namespace Day02RockPaperScissors;

public static class Turn
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        var outcome = OutcomeScore.Lose;
        if (own == opponent)
        {
            outcome = OutcomeScore.Draw;
        }
        if (own > opponent)
        {
            outcome = OutcomeScore.Win;
        }

        return new Score(own, outcome);
    }
}
