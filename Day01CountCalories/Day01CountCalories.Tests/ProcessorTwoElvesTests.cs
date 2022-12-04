namespace Day01CountCalories.Tests;

public class ProcessorTwoElvesTests
{
    [Fact]
    public void SingleFoodItem()
    {
        string[] input = { "1000", "", "2000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(2000, actual);
    }

    [Fact]
    public void MixedNumberOfFoodItems()
    {
        string[] input = { "1000", "2000", "", "2000", "3000", "4000" };
        
        var actual = Processor.Process(1, input);
        
        Assert.Equal(9000, actual);
    }
}