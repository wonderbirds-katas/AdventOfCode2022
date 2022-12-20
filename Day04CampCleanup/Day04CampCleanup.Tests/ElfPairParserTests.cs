namespace Day04CampCleanup.Tests;

public class ElfPairParserTests
{
    [Theory]
    [InlineData("1-1,2-2", new []{ 1 }, new[] { 2 })]
    public void NextTestWithoutMeaningfulName(string input, int[] expectedFirstElfSections, int[] expectedSecondElfSections)
    {
        var actual = "1-1,2-2".Parse();
        actual.Should().ContainSections(expectedFirstElfSections, expectedSecondElfSections);
    }
}