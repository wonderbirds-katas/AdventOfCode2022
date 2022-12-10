namespace Day02RockPaperScissors;

public class Round
{
    private readonly ShapeScore _opponent;
    private readonly ShapeScore _own;
    
    public Round(ShapeScore opponent, ShapeScore own)
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