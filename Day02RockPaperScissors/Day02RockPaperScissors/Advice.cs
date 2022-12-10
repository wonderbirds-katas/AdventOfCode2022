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

    public Round CalculateRound()
    {
        var own = DesiredOutcome switch
        {
            OutcomeScore.Lose => CalculateShapeToLose(),
            OutcomeScore.Draw => CalculateShapeForDraw(),
            _ => CalculateShapeToWin()
        };
        return new Round(Opponent, own);
    }

    private ShapeScore CalculateShapeToLose() =>
        Opponent switch
        {
            ShapeScore.Scissors => ShapeScore.Paper,
            ShapeScore.Rock => ShapeScore.Scissors,
            _ => ShapeScore.Rock,
        };

    private ShapeScore CalculateShapeForDraw() => Opponent;

    private ShapeScore CalculateShapeToWin() =>
        Opponent switch
        {
            ShapeScore.Paper => ShapeScore.Scissors,
            ShapeScore.Rock => ShapeScore.Paper,
            _ => ShapeScore.Rock,
        };
}