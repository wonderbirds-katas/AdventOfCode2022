namespace Day03RucksackReorganization.Tests;

public class ItemTests
{
    [Theory]
    [InlineData('a', 1)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    public void Priority(char type, int expected) => new Item(type).Priority.Should().Be(expected);
}
