namespace Day04CampCleanup.Tests;

public class ElfPairParserTests
{
    [Theory]
    [InlineData("1-1,2-2", new []{ 1 }, new[] { 2 })]
    [InlineData("99-99,123-123", new []{ 99 }, new[] { 123 })]
    public void NextTestWithoutMeaningfulName(string input, int[] expectedFirstElfSections, int[] expectedSecondElfSections)
    {
        var actual = input.Parse();
        actual.Should().ContainSections(expectedFirstElfSections, expectedSecondElfSections);
    }
}