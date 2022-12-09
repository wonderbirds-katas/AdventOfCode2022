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
