namespace Day02RockPaperScissors;

public readonly record struct Score(int Shape, int Outcome)
{
    public int Sum => Shape + Outcome;
}
