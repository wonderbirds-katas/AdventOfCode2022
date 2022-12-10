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

    public Round CalculateRound() =>
        _desiredOutcome switch
        {
            OutcomeScore.Lose => CalculateShapeToLose(),
            OutcomeScore.Draw => CalculateShapeForDraw(),
            _ => CalculateShapeToWin()
        };

    private Round CalculateShapeToLose()
    {
        return _opponent switch
        {
            ShapeScore.Scissors => new Round(_opponent, ShapeScore.Paper),
            ShapeScore.Rock => new Round(_opponent, ShapeScore.Scissors),
            _ => new Round(_opponent, ShapeScore.Rock),
        };
    }

    private Round CalculateShapeForDraw()
    {
        return new Round(_opponent, _opponent);
    }

    private Round CalculateShapeToWin()
    {
        return _opponent switch
        {
            ShapeScore.Paper => new Round(_opponent, ShapeScore.Scissors),
            ShapeScore.Rock => new Round(_opponent, ShapeScore.Paper),
            _ => new Round(_opponent, ShapeScore.Rock)
        };
    }
}