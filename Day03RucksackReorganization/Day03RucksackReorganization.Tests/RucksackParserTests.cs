namespace Day03RucksackReorganization.Tests;

public class RucksackParserTests
{
    [Fact]
    public void EmptyLine()
    {
        var expected = new Rucksack();
        
        const string emptyLine = "";
        var actual = emptyLine.Parse();
        
        Assert.Equal(expected, actual);
    }
}
