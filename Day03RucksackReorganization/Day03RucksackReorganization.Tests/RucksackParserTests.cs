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
        var expected = new Rucksack();
        expected.FirstCompartment.Add(new Item('a'));
        expected.SecondCompartment.Add(new Item('b'));

        const string lineWithTwoItems = "aa";
        var actual = lineWithTwoItems.Parse();
        
        Assert.Equal(expected.FirstCompartment.Items, actual.SecondCompartment.Items);
    }
}
