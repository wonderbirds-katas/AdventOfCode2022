namespace Day02RockPaperScissors;

public static class FileContentsParserExtensions
{
    public static IEnumerable<(ShapeScore, ShapeScore)> Parse(this IEnumerable<string> fileLines,
        ILineParser lineParser) =>
        fileLines.Select(lineParser.ParseLine);
}
