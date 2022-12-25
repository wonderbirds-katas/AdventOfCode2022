using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class CrateStackEqualityTests
{
    [Fact]
    public void EmptyStacks()
    {
        var actual = new CrateStack();
        var expected = new CrateStack();
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData('A', 'B', false)]
    [InlineData('C', 'C', true)]
    public void SingleCrate(char leftCrate, char rightCrate, bool expected) =>
        RunTest(expected, new[] { leftCrate }, new[] { rightCrate });

    [Theory]
    [InlineData(new[] { 'A', 'B' }, new[] { 'B', 'A' }, false)]
    [InlineData(new[] { 'A', 'B' }, new[] { 'A', 'C' }, false)]
    [InlineData(new[] { 'A', 'B' }, new[] { 'B', 'B' }, false)]
    [InlineData(new[] { 'C', 'X', 'Z' }, new[] { 'C', 'X', 'Z' }, true)]
    public void MultipleCrates(char[] leftCrates, char[] rightCrates, bool expected) =>
        RunTest(expected, leftCrates, rightCrates);

    private static void RunTest(bool expected, char[] leftCrates, char[] rightCrates)
    {
        var left = CreateStackWithCrates(leftCrates);
        var right = CreateStackWithCrates(rightCrates);

        (left == right).Should().Be(expected);
    }

    private static CrateStack CreateStackWithCrates(char[] crates)
    {
        var result = new CrateStack();
        foreach (var crate in crates)
        {
            result.AddOnTop(crate);
        }

        return result;
    }
}
