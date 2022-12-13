namespace Day03RucksackReorganization.Tests;

public class RucksackParserTests
{
    [Fact]
    public void EmptyLine()
    {
        var expected = new Rucksack(new Compartment(), new Compartment());
        
        const string emptyLine = "";
        var actual = emptyLine.Parse();
        
        Assert.Equal(expected, actual);
    }
}
