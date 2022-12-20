namespace Day03RucksackReorganization.Tests;

public class CommonItemDetectorTests
{
    [Theory]
    [InlineData('a')]
    [InlineData('z')]
    public void AnalyzeListOfGroups(char typeOfCommonItem)
    {
        var common = new Item(typeOfCommonItem);
        var items = new[] {common};
        var rucksacks = new Rucksack[]{ new (items), new(items), new(items) };
        var groups = new List<Group> { new(rucksacks) };

        var actual = groups.Analyze();

        actual.Should().ContainSingle()
            .Which.Priority.Should().Be(common.Priority);
    }
}