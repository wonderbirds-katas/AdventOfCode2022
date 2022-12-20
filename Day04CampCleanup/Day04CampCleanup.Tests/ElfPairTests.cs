namespace Day04CampCleanup.Tests;

public class ElfPairTests
{
    [Theory]
    [InlineData(new[] { 1 }, new[] { 2 })]
    public void NotFullyIntersectingSectionAssignments(int[] firstElfSections, int[] secondElfSections)
    {
        var actual = new ElfPair(firstElfSections, secondElfSections).IsOneSectionFullyContained();
        actual.Should().Be(false);
    }
}