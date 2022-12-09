namespace Day02RockPaperScissors;

public class LineParser : ILineParser
{
    public (ShapeScore opponentShape, ShapeScore ownShape) ParseLine(string line)
    {
        var opponentShape = line[0] switch
        {
            'A' => ShapeScore.Rock,
            'B' => ShapeScore.Paper,
            'C' => ShapeScore.Scissors
        };

        var ownShape = line[2] switch
        {
            'X' => ShapeScore.Rock,
            'Y' => ShapeScore.Paper,
            'Z' => ShapeScore.Scissors
        };

        return (opponentShape, ownShape);
    }
}