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
    public void SingleTree()
    {
        var treeHeightGrid = new[] { "1" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(1);
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
        const int expected = 16;
        
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(expected);
    }
}

public class TestsReplacingTheirCounterpartsInVisibleTreesCounterTests
{
    [Fact]
    public void SingleTree()
    {
        var treeHeightGrid = new[] { "1" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(1);
    }

    [Fact]
    public void FourTrees()
    {
        var treeHeightGrid = new[] { "11", "11" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(4);
    }

    [Fact]
    public void NineTreesWithShortestInTheMiddle()
    {
        var treeHeightGrid = new[] { "111", "101", "111" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(8);
    }

    [Fact]
    public void NineTreesWithSameHeight()
    {
        var treeHeightGrid = new[] { "111", "111", "111" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(8);
    }

    [Fact]
    public void NineTreesWithOuterTreesSmallerThanMiddle()
    {
        var treeHeightGrid = new[] { "111", "121", "111" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(9);
    }

    [Fact]
    public void NineTreesWithMiddleTreeOnlyVisibleFromTop()
    {
        var treeHeightGrid = new[] { "919", "929", "999" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(9);
    }

    [Fact]
    public void NineTreesWithMiddleTreeOnlyVisibleFromRight()
    {
        var treeHeightGrid = new[] { "999", "921", "999" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(9);
    }

    [Fact]
    public void NineTreesWithMiddleTreeOnlyVisibleFromBottom()
    {
        var treeHeightGrid = new[] { "999", "929", "919" };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(9);
    }
    
    [Fact]
    public void SixteenTreesWithInnerTreeLargerThanNeighbourButNotVisible()
    {
        var treeHeightGrid = new[]
        {
            "5555",
            "5235",
            "5555",
            "5555"
        };
        var actual = VisibleTreesCounter.Count(treeHeightGrid);
        actual.Should().Be(12);
    }

}