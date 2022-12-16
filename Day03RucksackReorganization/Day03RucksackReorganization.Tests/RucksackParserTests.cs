namespace Day03RucksackReorganization.Tests;
using FluentAssertions;

public class RucksackParserTests
{
    [Fact]
    public void EmptyLine()
    {
        const string emptyLine = "";
        var actual = emptyLine.Parse();

        actual.FirstCompartment.Items.Should().BeEmpty();
        actual.SecondCompartment.Items.Should().BeEmpty();
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
        
        RucksackAssertions.Equal(expected, actual);
    }

    private static void AddItemToCompartment(Item item, Compartment compartment)
    {
        compartment.Add(item);
        compartment.Items.Should().ContainSingle()
            .Which.Should().BeEquivalentTo(item);
    }
}
