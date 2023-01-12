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

    [Theory]
    [InlineData("99")]
    [InlineData("11")]
    [InlineData("00")]
    public void CountTreesVisibleFromLeft_TwoTreesWithSameHeight_Returns1(string treeHeightRow)
    {
        var treeHeightGrid = new []{ treeHeightRow };
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(treeHeightGrid);
        actual.Should().Be(1);
    }
    
    [Theory]
    [InlineData("98")]
    [InlineData("10")]
    public void CountTreesVisibleFromLeft_TwoTreesWithDescendingHeight_Returns1(string treeHeightRow)
    {
        var treeHeightGrid = new []{ treeHeightRow };
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(treeHeightGrid);
        actual.Should().Be(1);
    }

    [Theory]
    [InlineData("89")]
    public void CountTreesVisibleFromLeft_TwoTreesWithAscendingHeight_Returns2(string treeHeightRow)
    {
        var treeHeightGrid = new []{ treeHeightRow };
        var actual = VisibleTreesCounter.CountTreesVisibleFromLeft(treeHeightGrid);
        actual.Should().Be(2);
    }
}
