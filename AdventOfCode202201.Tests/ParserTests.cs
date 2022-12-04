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

    [Fact]
    public void TwoFoodItems()
    {
        const int firstItem = 200;
        const int secondItem = 400;
        const int expected = firstItem + secondItem;
        string[] input = { firstItem.ToString(), secondItem.ToString() };
        
        var actual = Parser.Parse(input);
        
        Assert.Equal(expected, actual);
    }
}