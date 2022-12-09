using Moq;

namespace Day02RockPaperScissors.Tests;

public class FileContentsParserTests
{
    [Fact]
    public void EmptyFileContents()
    {
        var actual = FileContentsParser.Parse(new string[] {});
        Assert.Empty(actual);
    }

    [Fact]
    public void SingleLineInFile()
    {
        var lineParserMock = Mock.Of<ILineParser>();
        var actual = FileContentsParser.Parse(new[] { "A X" });
        Assert.Empty(actual);
    }
}