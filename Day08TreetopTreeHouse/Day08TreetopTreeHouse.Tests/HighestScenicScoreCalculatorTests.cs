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

    [Fact]
    public void FourTrees()
    {
        var treeHeightGrid = new [] {"11", "11"};
        var actual = HighestScenicScoreCalculator.Calculate(TreeGrid.FromList(treeHeightGrid));
        actual.Should().Be(0);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 1)]
    [InlineData(2, 9)]
    public void NineTrees(int outerTreesHeight, int innerTreesHeight)
    {
        var treeHeightGrid = new string[3];
        treeHeightGrid[0] = $"{outerTreesHeight}{outerTreesHeight}{outerTreesHeight}";
        treeHeightGrid[1] = $"{outerTreesHeight}{innerTreesHeight}{outerTreesHeight}";
        treeHeightGrid[2] = $"{outerTreesHeight}{outerTreesHeight}{outerTreesHeight}";

        var actual = HighestScenicScoreCalculator.Calculate(TreeGrid.FromList(treeHeightGrid));
        
        actual.Should().Be(1);
    }
}