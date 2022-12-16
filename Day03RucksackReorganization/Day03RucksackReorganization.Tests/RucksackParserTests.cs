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
        
        var expected = new Rucksack();
        AddItemToCompartment(firstItem, expected.FirstCompartment);
        AddItemToCompartment(secondItem, expected.SecondCompartment);

        var actual = lineWithTwoItems.Parse();
        
        RucksackAsserts.Equal(expected, actual);
    }

    private static void AddItemToCompartment(Item item, Compartment compartment)
    {
        compartment.Add(item);
        Assert.Single(compartment.Items, added => added == item);
    }
}
