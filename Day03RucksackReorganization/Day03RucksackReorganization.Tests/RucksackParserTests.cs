namespace Day03RucksackReorganization.Tests;

public class RucksackParserTests
{
    // TODO: Implement test cases here
    [Theory(Skip = "TODO: Implement test cases here")]
    [InlineData("aa", new []{ 'a', 'a'})]
    public void NextTestWithoutMeaningfulName(string input, IEnumerable<char> expected)
    {
        var actual = input.Parse();

        var expectedItems = expected.Select(type => new Item(type));
        
        actual.Items.Should().BeEquivalentTo(expectedItems);
    }
}