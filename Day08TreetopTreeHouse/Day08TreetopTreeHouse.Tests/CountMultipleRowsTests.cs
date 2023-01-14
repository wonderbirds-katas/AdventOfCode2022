namespace Day08TreetopTreeHouse.Tests;

public class CountMultipleRowsTests
{
    [Fact]
    public void CountTreesVisibleFromLeft_TwoMixedRows()
    {
        var treeHeightGrid = new[]
        {
            "175389", // 1, 7, 8, 9 are visible from left
            "042276" // 0, 4, 7 are visible from left
        };
        
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(treeHeightGrid);
        actual.Should().Be(4 + 3);
    }
}