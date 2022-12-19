namespace Day03RucksackReorganization.Tests;

public class CommonItemDetectorTests
{
    [Fact]
    public void AnalyzeListOfGroups()
    {
        var rucksacks = new Rucksack[]{ new (), new(), new() };
        var groups = new List<Group> { new(rucksacks) };

        var actual = groups.Analyze();

        actual.Should().ContainSingle()
            .Which.Priority.Should().Be(1);
    }
}