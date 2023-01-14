namespace Day08TreetopTreeHouse.Tests;

public class VisibleTreesCounterTests
{
    [Fact]
    public void EmptyGrid()
    {
        var actual = VisibleTreesCounter.Count(Array.Empty<string>());
        actual.Should().Be(0);
    }

    [Fact]
    public void TwoMixedRows()
    {
        var treeHeightGrid = new[]
        {
            "175389", // 1, 7, 8, 9 are visible from left
            "042276" // 0, 4, 7 are visible from left
        };
        
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(4 + 3);
    }
}