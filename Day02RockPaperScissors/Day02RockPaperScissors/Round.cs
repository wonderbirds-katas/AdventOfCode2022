namespace Day02RockPaperScissors;

public class RoundReplacement
{
    private readonly ShapeScore _opponent;
    private readonly ShapeScore _own;
    
    public RoundReplacement(ShapeScore opponent, ShapeScore own)
    {
        _opponent = opponent;
        _own = own;
    }
    
    public Score Score()
    {
        var outcome = CalculateOutcome();

        return new Score(_own, outcome);
    }

    private OutcomeScore CalculateOutcome()
    {
        if (_own.IsGreaterThan(_opponent)) return OutcomeScore.Win;
        if (_own == _opponent) return OutcomeScore.Draw;
        return OutcomeScore.Lose;
    }

}
public class Round
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        return new RoundReplacement(opponent, own).Score();
    }
}
