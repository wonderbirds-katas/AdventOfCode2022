using Moq;

namespace Day02RockPaperScissors.Tests;

public class FileContentsParserTests
{
    private readonly Mock<ILineParser> _lineParserMock;

    public FileContentsParserTests()
    {
        _lineParserMock = new Mock<ILineParser>();
    }

    [Fact]
    public void EmptyFileContents()
    {
        var fileLines = new string[] { };
        
        var actual = fileLines.Parse(_lineParserMock.Object);
        
        Assert.Empty(actual);
    }

    [Fact]
    public void SingleLineInFile()
    {
        var fileLines = new[] { "A X" };
        
        var result = fileLines.Parse(_lineParserMock.Object);

        Assert.Collection(
            result,
            _ => _lineParserMock.Verify(x => x.ParseLine("A X"), Times.Once)
        );
    }

    [Fact]
    public void MultipleLinesInFile()
    {
        var fileLines = new[] { "A X", "B Y", "C Z" };
        
        var result = fileLines.Parse(_lineParserMock.Object);

        Assert.Collection(
            result,
            _ => _lineParserMock.Verify(x => x.ParseLine("A X"), Times.Once),
            _ => _lineParserMock.Verify(x => x.ParseLine("B Y"), Times.Once),
            _ => _lineParserMock.Verify(x => x.ParseLine("C Z"), Times.Once)
        );
    }
}