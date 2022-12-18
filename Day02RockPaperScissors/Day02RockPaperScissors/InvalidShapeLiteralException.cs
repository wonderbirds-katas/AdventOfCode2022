namespace Day02RockPaperScissors;

public class InvalidShapeLiteralException : Exception
{
    public InvalidShapeLiteralException(char shapeLiteral)
        : base($"Invalid shape literal '{shapeLiteral}'") { }
}
