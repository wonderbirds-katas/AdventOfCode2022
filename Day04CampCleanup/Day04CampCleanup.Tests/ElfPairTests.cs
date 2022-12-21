namespace Day04CampCleanup.Tests;

public class ElfPairTests
{
    [Theory]
    [InlineData(new[] { 1 }, new[] { 2 })]
    public void NotFullyIntersectingSectionAssignments(int[] firstElfSections, int[] secondElfSections)
    {
        new ElfPair(firstElfSections, secondElfSections)
            .IsOneSectionFullyContained()
            .Should().Be(false);
    }

    [Theory]
    [InlineData(new[] { 2 }, new[] { 2 })]
    [InlineData(new[] { 10, 11, 12 }, new[] { 10, 11, 12 })]
    [InlineData(new[] { 10, 11, 12 }, new[] { 9, 10, 11, 12, 13 })]
    [InlineData(new[] { 9, 10, 11, 12, 13 }, new[] { 10, 11, 12 })]
    public void FullyIntersectingSectionAssignments(int[] firstElfSections, int[] secondElfSections)
    {
        new ElfPair(firstElfSections, secondElfSections)
            .IsOneSectionFullyContained()
            .Should().Be(true);
    }
    
    [Theory]
    [InlineData(new[] { 1, 2 }, new[] { 2, 3 })]
    public void PartiallyIntersectingSectionAssignments(int[] firstElfSections, int[] secondElfSections)
    {
        new ElfPair(firstElfSections, secondElfSections)
            .IsOneSectionFullyContained()
            .Should().Be(true);
    }
}