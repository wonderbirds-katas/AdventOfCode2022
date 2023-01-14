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
    public void ThreeMixedRows()
    {
        var treeHeightGrid = new[]
        {
            // 9 trees: (1, 3), (7), (5, 7), (3, 4), (8), (9) are visible from the top
            "175389", // 5 trees: 1, 7, 8, 9 are visible from left + 9    is  visible from the right
            "042276", // 5 trees: 0, 4, 7    are visible from left + 6, 7 are visible from the right
            "367475", // 5 trees: 3, 6, 7    are visible from left + 5, 7 are visible from the right
            // 10 trees: (3), (6, 7), (7), (4), (7, 8), (5, 6, 9) are visible from the bottom
        };
        
        // 103
        // 746
        // 527
        // 324
        // 877
        // 965
        
        // 175389
        // 042276
        
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(34);
    }
}