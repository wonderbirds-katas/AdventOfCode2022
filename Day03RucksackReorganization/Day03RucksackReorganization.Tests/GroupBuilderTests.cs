namespace Day03RucksackReorganization.Tests;

public class GroupBuilderTests
{
    [Fact]
    public void SingleGroup()
    {
        var rucksacks = new List<Rucksack> { new(), new(), new() };

        var actual = rucksacks.Group();

        actual.Should().ContainSingle().Which.Rucksacks.Should().HaveCount(3);
    }

    [Fact]
    public void TwoGroups()
    {
        var rucksacks = new List<Rucksack> { new(), new(), new(), new(), new(), new() };

        var actual = rucksacks.Group();

        actual.Should().HaveCount(2);
    }
}
