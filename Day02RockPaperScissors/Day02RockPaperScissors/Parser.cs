namespace Day02RockPaperScissors;

public static class Parser
{
    public static (ShapeScore opponentShape, ShapeScore ownShape) ParseLine(string line)
    {
        if (line[0] == 'B')
        {
            return (ShapeScore.Paper, ShapeScore.Rock);
        }
        return (ShapeScore.Rock, ShapeScore.Rock);
    }
}