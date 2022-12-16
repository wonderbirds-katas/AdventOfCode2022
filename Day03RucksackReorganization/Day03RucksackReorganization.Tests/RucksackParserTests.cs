namespace Day03RucksackReorganization.Tests;

public class RucksackParserTests
{
    [Fact]
    public void EmptyLine()
    {
        const string emptyLine = "";
        var actual = emptyLine.Parse();
        
        Assert.Empty(actual.FirstCompartment.Items);
        Assert.Empty(actual.SecondCompartment.Items);
    }
    
    // TODO: Create RucksackParserTests for edge case of odd number of Items
    
    [Fact]
    public void LineWithTwoItems()
    {
        var expectedRucksack = new Rucksack();
        
        var expectedFirstItem = new Item('a');
        expectedRucksack.FirstCompartment.Add(expectedFirstItem);
        Assert.Single(expectedRucksack.FirstCompartment.Items, item => expectedFirstItem == item);
        
        var expectedSecondItem = new Item('b');
        expectedRucksack.SecondCompartment.Add(expectedSecondItem);
        Assert.Single(expectedRucksack.SecondCompartment.Items, item => expectedSecondItem == item);

        const string lineWithTwoItems = "ab";
        var actual = lineWithTwoItems.Parse();
        
        Assert.Equal(expectedRucksack.FirstCompartment.Items, actual.FirstCompartment.Items);
        Assert.Equal(expectedRucksack.SecondCompartment.Items, actual.SecondCompartment.Items);
    }
}
