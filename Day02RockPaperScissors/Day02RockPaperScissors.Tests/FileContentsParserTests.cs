namespace Day02RockPaperScissors.Tests;

public class FileContentsParserTests
{
    [Fact]
    public void EmptyFileContents()
    {
        var actual = FileContentsParser.Parse(new string[] {});
        Assert.Empty(actual);
    }
}