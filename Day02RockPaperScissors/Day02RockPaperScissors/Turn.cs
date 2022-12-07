namespace Day02RockPaperScissors;

public static class Turn
{
    private const int Rock = 1;
    private const int Paper = 2;
    private const int Invalid = -1;

    public static Score Score(Shape opponent, Shape own)
    {
        var outcomeScore = Outcome.Draw;
        if (own > opponent)
        {
            outcomeScore = Outcome.Win;
        }

        var shapeScore = own switch
        {
            Shape.Rock => Rock,
            Shape.Paper => Paper,
            _ => Invalid
        };

        return new Score(shapeScore, outcomeScore);
    }
}
