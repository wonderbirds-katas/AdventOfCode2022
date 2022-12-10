namespace Day02RockPaperScissors;

public class FileContentsParser
{
    private readonly ILineParser _lineParser;

    public FileContentsParser(ILineParser lineParser)
    {
        _lineParser = lineParser;
    }

    public IEnumerable<(ShapeScore, ShapeScore)> Parse(IEnumerable<string> fileLines)
    {
        return fileLines.Select(_lineParser.ParseLine);
    }
}

public static class FileContentsParserExtensions
{
    public static IEnumerable<(ShapeScore, ShapeScore)> Parse(this IEnumerable<string> fileLines,
        ILineParser lineParser)
    {
        return new FileContentsParser(lineParser).Parse(fileLines);
    }
}
