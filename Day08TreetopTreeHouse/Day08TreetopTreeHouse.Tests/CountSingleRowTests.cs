namespace Day08TreetopTreeHouse.Tests;

public class CountSingleRowTests
{
    [Fact]
    public void CountTreesVisibleFromLeft_SingleTree_Returns1()
        => GivenThisRowOfTreeHeights("9")
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("99")]
    [InlineData("11")]
    [InlineData("00")]
    public void CountTreesVisibleFromLeft_TwoTreesWithSameHeight_Returns1(string treeHeightRow)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("98")]
    [InlineData("10")]
    public void CountTreesVisibleFromLeft_TwoTreesWithDescendingHeight_Returns1(string treeHeightRow)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(1);

    [Theory]
    [InlineData("89", 2)]
    [InlineData("789", 3)]
    [InlineData("6789", 4)]
    public void CountTreesVisibleFromLeft_TreesWithAscendingHeight_ReturnsCorrectNumber(string treeHeightRow, int expected)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(expected);

    [Theory]
    [InlineData("121", 2)]
    [InlineData("213", 2)]
    [InlineData("2354", 3)]
    [InlineData("2756", 2)]
    [InlineData("2858", 2)]
    public void CountTreesVisibleFromLeft_TreesWithAlternatingHeight_ReturnsCorrectNumber(string treeHeightRow, int expected)
        => GivenThisRowOfTreeHeights(treeHeightRow)
            .WhenCountingTreesVisibleFromLeft()
            .ThenItReturns(expected);

    // TODO: Handle edge case of empty string in input tree grid string list
    
    private static CountSingleRowTests.TestFixture GivenThisRowOfTreeHeights(string treeHeightRow)
    {
        return new CountSingleRowTests.TestFixture(treeHeightRow);
    }

    internal class TestFixture
    {
        private readonly string _treeHeightRow;
        private int _numberOfTreesVisibleFromLeft;

        public TestFixture(string treeHeightRow)
            => _treeHeightRow = treeHeightRow;

        public CountSingleRowTests.TestFixture WhenCountingTreesVisibleFromLeft()
        {
            _numberOfTreesVisibleFromLeft = VisibleTreesCounter.CountTreesVisibleFromLeft(new[] {_treeHeightRow});
            return this;
        }

        public void ThenItReturns(int expected)
            => _numberOfTreesVisibleFromLeft.Should().Be(expected);
    }
}