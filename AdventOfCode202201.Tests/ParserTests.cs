namespace AdventOfCode202201.Tests;

public class ParserTests
{
    [Fact]
    public void SingleFoodItem()
    {
        const int expected = 1000;
        string[] input = { expected.ToString() };
        
        var actual = Parser.Parse(input);
        
        Assert.Equal(expected, actual);
    }
}