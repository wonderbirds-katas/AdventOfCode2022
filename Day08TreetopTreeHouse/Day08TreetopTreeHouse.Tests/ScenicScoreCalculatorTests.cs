namespace Day08TreetopTreeHouse.Tests;

public class ScenicScoreCalculatorTests
{
    [Fact]
    public void SingleTree()
    {
        var treeHeightStrings = new List<string> {"1"};
        var treeHeights = Matrix<int>.FromList(treeHeightStrings);

        var actual = ScenicScoreCalculator.Calculate(treeHeights);

        var expectedStrings = new List<string> {"0"};
        var expected = Matrix<int>.FromList(expectedStrings);

        actual.Should().Be(expected);
    }
}