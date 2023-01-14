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
            "175389", // 1, 7, 8, 9 are visible from left + 9    is  visible from the right
            "042276", // 0, 4, 7    are visible from left + 6, 7 are visible from the right
            "367475", // 3, 6, 7    are visible from left + 5, 7 are visible from the right
        };
        
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(4 + 1 + 3 + 2 + 3 + 2);
    }
}