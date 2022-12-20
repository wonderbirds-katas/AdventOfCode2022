namespace Day03RucksackReorganization.Tests;

public class RucksackParserTests
{
    [Theory]
    [InlineData("aa", new []{ 'a', 'a'})]
    [InlineData("abcdefGHIJK", new []{ 'a', 'b', 'c', 'd', 'e', 'f', 'G', 'H', 'I', 'J', 'K'})]
    public void AddItems(string inputLine, IEnumerable<char> expectedItemTypes)
    {
        var actual = inputLine.Parse();

        var expectedItems = expectedItemTypes.Select(type => new Item(type));
        
        actual.Items.Should().BeEquivalentTo(expectedItems);
    }
}