namespace Day08TreetopTreeHouse.Tests;

public class VisibleTreesCounterTests
{
    [Fact]
    public void CountTreesVisibleFromLeft_EmptyPatch_Returns0()
    {
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(Array.Empty<string>());
        actual.Should().Be(0);
    }
    
    [Fact]
    public void CountTreesVisibleFromLeft_SingleTree_Returns1()
    {
        var treeHeightGrid = new []{ "9" };
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(treeHeightGrid);
        actual.Should().Be(1);
    }
}
