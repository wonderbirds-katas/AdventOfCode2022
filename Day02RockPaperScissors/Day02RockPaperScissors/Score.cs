namespace Day02RockPaperScissors;

public readonly record struct Score(int ShapePoints, int OutcomePoints)
{
    public int Sum => ShapePoints + OutcomePoints;
}
