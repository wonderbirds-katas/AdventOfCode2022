namespace Day02RockPaperScissors;

public class Advice
{
    public ShapeScore Opponent { get; }
    
    public OutcomeScore DesiredOutcome { get; }

    public Advice(ShapeScore opponent, OutcomeScore desiredOutcome)
    {
        Opponent = opponent;
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
        return Opponent switch
        {
            ShapeScore.Scissors => new Round(Opponent, ShapeScore.Paper),
            ShapeScore.Rock => new Round(Opponent, ShapeScore.Scissors),
            _ => new Round(Opponent, ShapeScore.Rock),
        };
    }

    private Round CalculateShapeForDraw()
    {
        return new Round(Opponent, Opponent);
    }

    private Round CalculateShapeToWin()
    {
        return Opponent switch
        {
            ShapeScore.Paper => new Round(Opponent, ShapeScore.Scissors),
            ShapeScore.Rock => new Round(Opponent, ShapeScore.Paper),
            _ => new Round(Opponent, ShapeScore.Rock)
        };
    }
}