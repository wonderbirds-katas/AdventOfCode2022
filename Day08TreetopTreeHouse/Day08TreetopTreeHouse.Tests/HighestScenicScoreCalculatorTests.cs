namespace Day08TreetopTreeHouse.Tests;

public class HighestScenicScoreCalculatorTests
{
    [Fact]
    public void SingleTree()
    {
        var treeHeightStrings = new List<string> {"1"};

        var actual = HighestScenicScoreCalculator.Calculate(TreeGrid.FromList(treeHeightStrings));

        actual.Should().Be(0);
    }
}