namespace AdventOfCode202201.Tests;

public class ParserTwoElvesTests
{
    [Fact]
    public void SingleFoodItem()
    {
        string[] input = { "1000", "", "2000" };
        
        var actual = Parser.Process(1, input);
        
        Assert.Equal(2000, actual);
    }

    [Fact]
    public void MixedNumberOfFoodItems()
    {
        string[] input = { "1000", "2000", "", "2000", "3000", "4000" };
        
        var actual = Parser.Process(1, input);
        
        Assert.Equal(9000, actual);
    }
}