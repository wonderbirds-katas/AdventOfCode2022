namespace Day02RockPaperScissors;

public static class Turn
{
    public static int Score(Shape opponent, Shape own)
    {
        var outcomeScore = 3;
        if (own > opponent)
        {
            outcomeScore = 6;
        }

        var shapeScore = own switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            _ => 0
        };

        return outcomeScore + shapeScore;
    }
}