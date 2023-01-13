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
        => GivenRowOfTreeHeights("9")
            .WhenCountingVisibleFromLeft()
            .ThenReturn(1);

    [Theory]
    [InlineData("99")]
    [InlineData("11")]
    [InlineData("00")]
    public void CountTreesVisibleFromLeft_TwoTreesWithSameHeight_Returns1(string treeHeightRow)
        => GivenRowOfTreeHeights(treeHeightRow)
            .WhenCountingVisibleFromLeft()
            .ThenReturn(1);

    [Theory]
    [InlineData("98")]
    [InlineData("10")]
    public void CountTreesVisibleFromLeft_TwoTreesWithDescendingHeight_Returns1(string treeHeightRow)
        => GivenRowOfTreeHeights(treeHeightRow)
            .WhenCountingVisibleFromLeft()
            .ThenReturn(1);

    [Theory]
    [InlineData("89", 2)]
    [InlineData("789", 3)]
    [InlineData("6789", 4)]
    public void CountTreesVisibleFromLeft_TreesWithAscendingHeight_ReturnsCorrectNumber(string treeHeightRow, int expected)
        => GivenRowOfTreeHeights(treeHeightRow)
            .WhenCountingVisibleFromLeft()
            .ThenReturn(expected);

    [Theory]
    [InlineData("121", 2)]
    [InlineData("213", 2)]
    public void CountTreesVisibleFromLeft_TreesWithAlternatingHeight_ReturnsCorrectNumber(string treeHeightRow, int expected)
        => GivenRowOfTreeHeights(treeHeightRow)
            .WhenCountingVisibleFromLeft()
            .ThenReturn(expected);

    // TODO: Handle edge case of empty string in input tree patch string list
    
    private static TestFixture GivenRowOfTreeHeights(string treeHeightRow)
    {
        return new TestFixture(treeHeightRow);
    }

    internal class TestFixture
    {
        private readonly string _treeHeightRow;
        private int _numberOfTreesVisibleFromLeft;

        public TestFixture(string treeHeightRow)
            => _treeHeightRow = treeHeightRow;

        public TestFixture WhenCountingVisibleFromLeft()
        {
            _numberOfTreesVisibleFromLeft = VisibleTreesCounter.CountTreesVisibleFromLeft(new[] {_treeHeightRow});
            return this;
        }

        public void ThenReturn(int expected)
            => _numberOfTreesVisibleFromLeft.Should().Be(expected);
    }
}