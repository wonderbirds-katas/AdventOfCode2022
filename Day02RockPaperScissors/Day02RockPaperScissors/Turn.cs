namespace Day02RockPaperScissors;

public static class Turn
{
    public static Score Score(Shape opponent, Shape own)
    {
        var outcomeScore = OutcomeScore.Draw;
        if (own > opponent)
        {
            outcomeScore = OutcomeScore.Win;
        }

        var shapeScore = own switch
        {
            Shape.Rock => ShapeScore.Rock,
            Shape.Paper => ShapeScore.Paper,
            Shape.Scissors => ShapeScore.Scissors,
            _ => ShapeScore.Invalid
        };

        return new Score(shapeScore, outcomeScore);
    }
}
