namespace Day02RockPaperScissors;

public readonly record struct Score(ShapeScore Shape, OutcomeScore Outcome)
{
    public int Sum => (int)Shape + (int)Outcome;
}
