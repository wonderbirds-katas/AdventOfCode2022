namespace Day08TreetopTreeHouse.Tests;

public class FromLeftCounterTests
{
    [Fact]
    public void SingleTree()
        => GivenThisRowOfTreeHeights("9")
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("99")]
    [InlineData("11")]
    [InlineData("00")]
    public void TwoTreesWithSameHeight(string treeHeightRow)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("98")]
    [InlineData("10")]
    public void TwoTreesWithDescendingHeight(string treeHeightRow)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("89", 2)]
    [InlineData("789", 3)]
    [InlineData("6789", 4)]
    public void TreesWithAscendingHeight(string treeHeightRow, int expected)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(expected);

    [Theory]
    [InlineData("121", 2)]
    [InlineData("213", 2)]
    [InlineData("2354", 3)]
    [InlineData("2756", 2)]
    [InlineData("2858", 2)]
    public void TreesWithMixedHeight(string treeHeightRow, int expected)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(expected);

    // TODO: Handle edge case of empty string in input tree grid string list
    
    private static TestFixture GivenThisRowOfTreeHeights(string treeHeightRow)
    {
        return new TestFixture(treeHeightRow);
    }

    internal class TestFixture
    {
        private readonly string _treeHeightRow;
        private int _numberOfTreesVisibleFromLeft;

        public TestFixture(string treeHeightRow)
            => _treeHeightRow = treeHeightRow;

        public TestFixture WhenCountingTreesVisibleFromLeft()
        {
            _numberOfTreesVisibleFromLeft = FromLeftCounter.Count(_treeHeightRow);
            return this;
        }

        public void ThenItReturns(int expected)
            => _numberOfTreesVisibleFromLeft.Should().Be(expected);
    }
}