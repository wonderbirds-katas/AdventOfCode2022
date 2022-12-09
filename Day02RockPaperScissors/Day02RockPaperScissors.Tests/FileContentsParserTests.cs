using Moq;

namespace Day02RockPaperScissors.Tests;

public class FileContentsParserTests
{
    private readonly Mock<ILineParser> _lineParserMock;
    private readonly FileContentsParser _fileContentsParser;

    public FileContentsParserTests()
    {
        _lineParserMock = new Mock<ILineParser>();
        _fileContentsParser = new FileContentsParser(_lineParserMock.Object);
    }

    [Fact]
    public void EmptyFileContents()
    {
        var actual = _fileContentsParser.Parse(new string[] { });
        Assert.Empty(actual);
    }

    [Fact]
    public void SingleLineInFile()
    {
        var result = _fileContentsParser.Parse(new[] { "A X" });

        Assert.Collection(
            result,
            _ => _lineParserMock.Verify(x => x.ParseLine("A X"), Times.Once)
        );
    }

    [Fact]
    public void MultipleLinesInFile()
    {
        var result = _fileContentsParser.Parse(new[] { "A X", "B Y", "C Z" });

        Assert.Collection(
            result,
            _ => _lineParserMock.Verify(x => x.ParseLine("A X"), Times.Once),
            _ => _lineParserMock.Verify(x => x.ParseLine("B Y"), Times.Once),
            _ => _lineParserMock.Verify(x => x.ParseLine("C Z"), Times.Once)
        );
    }
}