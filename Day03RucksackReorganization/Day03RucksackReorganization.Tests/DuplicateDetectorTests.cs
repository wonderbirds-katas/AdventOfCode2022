namespace Day03RucksackReorganization.Tests;

public class DuplicateDetectorTests
{
    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('Z')]
    public void SingleDuplicateItem(char type)
    {
        var rucksack = RucksackBuilder.PackRucksackWith(new []{ type }, new []{ type });
        rucksack.Analyze().Type.Should().Be(type);
    }
}
