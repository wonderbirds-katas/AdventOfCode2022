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
}