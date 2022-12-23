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
}