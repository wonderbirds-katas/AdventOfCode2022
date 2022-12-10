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
        return new Round(_opponent, ShapeScore.Rock);
    }
}