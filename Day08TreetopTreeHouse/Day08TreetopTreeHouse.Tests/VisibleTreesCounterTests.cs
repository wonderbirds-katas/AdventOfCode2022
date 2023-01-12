namespace Day08TreetopTreeHouse.Tests;

public class VisibleTreesCounterTests
{
    [Fact]
    public void CountTreesVisibleFromLeft_EmptyPatch_Returns0()
    {
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(Array.Empty<string>());
        actual.Should().Be(0);
    }
}