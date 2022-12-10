namespace Day02RockPaperScissors;

public class Advice
{
    private readonly ShapeScore _opponent;

    public OutcomeScore DesiredOutcome { get; }

    public Advice(ShapeScore opponent, OutcomeScore desiredOutcome)
    {
        _opponent = opponent;
        DesiredOutcome = desiredOutcome;
    }

    public Round CalculateRound() =>
        DesiredOutcome switch
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