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
            "175389",
            "042276",
            "367475"
        };
        
        // Matrix of visible trees (1 = visible, 0 = not visible)
        // 111111 - Sum: 6
        // 110011 - Sum: 4
        // 111111 - Sum: 6
        // Sum of visible trees: 6+4+6 = 16
        var expected = 16;
        
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(expected);
    }
}