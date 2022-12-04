namespace AdventOfCode202201.Tests;

public class ProcessorThreeElvesTests
{
    [Fact]
    public void SingleFoodItem()
    {
        string[] input = { "1000", "", "2000", "", "3000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(3000, actual);
    }

    [Fact]
    public void MixedNumberOfFoodItemsWithHighestLast()
    {
        string[] input = { "1000", "2000", "", "2000", "3000", "4000", "", "3000", "4000", "5000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(12000, actual);
    }

    [Fact]
    public void MixedNumberOfFoodItemsWithHighestFirst()
    {
        string[] input = { "3000", "4000", "5000", "", "1000", "2000", "", "2000", "3000", "4000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(12000, actual);
    }
    
    [Fact]
    public void MixedNumberOfFoodItemsWithHighestSecond()
    {
        string[] input = { "1000", "2000", "", "3000", "4000", "5000", "", "2000", "3000", "4000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(12000, actual);
    }
}