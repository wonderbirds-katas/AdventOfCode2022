namespace Day02RockPaperScissors;

public static class Turn
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        var outcomeScore = OutcomeScore.Draw;
        if (own > opponent)
        {
            outcomeScore = OutcomeScore.Win;
        }

        return new Score(own, outcomeScore);
    }
}
