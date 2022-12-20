namespace Day03RucksackReorganization.Tests;

public class CommonItemDetectorTests
{
    [Theory]
    [InlineData('a')]
    [InlineData('z')]
    public void AnalyzeListOfGroups(char typeOfCommonItem)
    {
        var common = new Item(typeOfCommonItem);
        var rucksacks = new Rucksack[]{ new (), new(), new() };
        rucksacks[0].Add(common);
        rucksacks[1].Add(common);
        rucksacks[2].Add(common);
        
        var groups = new List<Group> { new(rucksacks) };

        var actual = groups.Analyze();

        actual.Should().ContainSingle()
            .Which.Priority.Should().Be(common.Priority);
    }
}