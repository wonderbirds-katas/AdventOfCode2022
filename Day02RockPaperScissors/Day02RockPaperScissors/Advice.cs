namespace Day02RockPaperScissors;

public class Advice
{
    private readonly ShapeScore _opponent;
    private readonly OutcomeScore _desiredOutcome;

    public Advice(ShapeScore opponent, OutcomeScore desiredOutcome)
    {
        _opponent = opponent;
        _desiredOutcome = desiredOutcome;
    }

    public Round CalculateRound()
    {
        return _opponent switch
        {
            ShapeScore.Paper => new Round(_opponent, ShapeScore.Scissors),
            ShapeScore.Rock => new Round(_opponent, ShapeScore.Paper),
            _ => new Round(_opponent, ShapeScore.Rock)
        };
    }
}