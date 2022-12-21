namespace Day04CampCleanup.Tests;

public class ElfPairParserTests
{
    [Theory]
    [InlineData("1-1,2-2", new []{ 1 }, new[] { 2 })]
    [InlineData("99-99,123-123", new []{ 99 }, new[] { 123 })]
    public void RangeConsistsOfSingleNumber(string input, int[] expectedFirstElfSections, int[] expectedSecondElfSections)
    {
        input.Parse()
            .Should().ContainSections(expectedFirstElfSections, expectedSecondElfSections);
    }
    
    [Theory]
    [InlineData("1-2,3-4", new []{ 1, 2 }, new[] { 3, 4 })]
    [InlineData("10-12,99-101", new []{ 10, 11, 12 }, new[] { 99, 100, 101 })]
    public void RangeConsistsOfSequenceOfNumbers(string input, int[] expectedFirstElfSections, int[] expectedSecondElfSections)
    {
        input.Parse()
            .Should().ContainSections(expectedFirstElfSections, expectedSecondElfSections);
    }
}