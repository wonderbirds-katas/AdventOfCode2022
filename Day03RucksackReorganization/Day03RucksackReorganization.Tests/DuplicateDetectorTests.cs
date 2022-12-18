namespace Day03RucksackReorganization.Tests;

public class DuplicateDetectorTests
{
    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('Z')]
    public void SingleDuplicateItem(char type) => RunTestFor(new[] { type }, new[] { type }, type);

    // TODO: What should happen, if there are more than one duplicate item?

    [Theory]
    [InlineData(new[] { 'a', 'b' }, new[] { 'a', 'c' }, 'a')]
    [InlineData(new[] { 'A', 'b' }, new[] { 'A', 'c' }, 'A')]
    [InlineData(new[] { 'n', 'b', 'z' }, new[] { 'n', 'c', 'Y' }, 'n')]
    public void MultipleItemsFirstIsDuplicate(
        char[] itemsInFirstCompartment,
        char[] itemsInSecondCompartment,
        char expected
    ) => RunTestFor(itemsInFirstCompartment, itemsInSecondCompartment, expected);

    [Theory]
    [InlineData(new[] { 'a', 'b' }, new[] { 'D', 'b' }, 'b')]
    [InlineData(new[] { 'a', 'b', 'Q', 'b' }, new[] { 'D', 'Q', 'E', 'D' }, 'Q')]
    public void MultipleItemsAnyIsDuplicate(
        char[] itemsInFirstCompartment,
        char[] itemsInSecondCompartment,
        char expected
    ) => RunTestFor(itemsInFirstCompartment, itemsInSecondCompartment, expected);

    private static void RunTestFor(
        char[] itemsInFirstCompartment,
        char[] itemsInSecondCompartment,
        char expected
    )
    {
        var rucksack = RucksackBuilder.PackRucksackWith(
            itemsInFirstCompartment,
            itemsInSecondCompartment
        );
        rucksack.Analyze().Type.Should().Be(expected);
    }
}
