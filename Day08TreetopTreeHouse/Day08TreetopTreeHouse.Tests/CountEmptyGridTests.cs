namespace Day08TreetopTreeHouse.Tests;

public class CountEmptyGridTests
{
    [Fact]
    public void CountTreesVisibleFromLeft_EmptyGrid_Returns0()
    {
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(Array.Empty<string>());
        actual.Should().Be(0);
    }
}