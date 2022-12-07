namespace Day02RockPaperScissors;

public readonly record struct Score(int Shape, OutcomeScore Outcome)
{
    public int Sum => Shape + (int)Outcome;
}
