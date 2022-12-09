namespace Day02RockPaperScissors;

public static class Parser
{
    public static (ShapeScore opponentShape, ShapeScore ownShape) ParseLine(string line)
    {
        var opponentShape = line[0] switch
        {
            'A' => ShapeScore.Rock,
            'B' => ShapeScore.Paper
        };

        return (opponentShape, ShapeScore.Rock);
    }
}