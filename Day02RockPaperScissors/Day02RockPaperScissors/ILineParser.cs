namespace Day02RockPaperScissors;

public interface ILineParser
{
    (ShapeScore opponentShape, ShapeScore ownShape) ParseLine(string line);
}