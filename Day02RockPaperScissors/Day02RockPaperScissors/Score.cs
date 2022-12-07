namespace Day02RockPaperScissors;

public readonly record struct Score(int Shape, Outcome Outcome)
{
    public int Sum => Shape + (int)Outcome;
}
