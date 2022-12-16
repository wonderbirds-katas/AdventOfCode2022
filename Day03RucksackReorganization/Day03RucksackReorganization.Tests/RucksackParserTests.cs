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
        var firstItem = new Item('a');
        var secondItem = new Item('b');
        var lineWithTwoItems = $"{firstItem.Type}{secondItem.Type}";
        
        var expectedRucksack = new Rucksack();
        AddItemToCompartment(firstItem, expectedRucksack.FirstCompartment);
        AddItemToCompartment(secondItem, expectedRucksack.SecondCompartment);

        var actual = lineWithTwoItems.Parse();
        
        Assert.Equal(expectedRucksack.FirstCompartment.Items, actual.FirstCompartment.Items);
        Assert.Equal(expectedRucksack.SecondCompartment.Items, actual.SecondCompartment.Items);
    }

    private static void AddItemToCompartment(Item item, Compartment compartment)
    {
        compartment.Add(item);
        Assert.Single(compartment.Items, added => added == item);
    }
}
