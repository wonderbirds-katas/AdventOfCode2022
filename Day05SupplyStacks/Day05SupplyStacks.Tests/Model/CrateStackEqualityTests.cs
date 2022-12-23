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
    public void SingleCrate(char leftCrate, char rightCrate, bool expected)
    {
        var left = new CrateStack();
        left.AddOnTop(leftCrate);

        var right = new CrateStack();
        right.AddOnTop(rightCrate);
        
        (left == right).Should().Be(expected);
    }
    
    [Theory]
    [InlineData(new[] { 'A', 'B' }, new[] { 'B', 'A' }, false)]
    [InlineData(new[] { 'A', 'B' }, new[] { 'A', 'C' }, false)]
    [InlineData(new[] { 'A', 'B' }, new[] { 'B', 'B' }, false)]
    public void MultipleCrates(char[] leftCrates, char[] rightCrates, bool expected)
    {
        var left = new CrateStack();
        foreach (var crate in leftCrates)
        {
            left.AddOnTop(crate);
        }

        var right = new CrateStack();
        foreach (var crate in rightCrates)
        {
            right.AddOnTop(crate);
        }
        
        (left == right).Should().Be(expected);
    }
}