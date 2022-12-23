using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class OrderedStackEqualityTests
{
    [Fact]
    public void Empty()
    {
        var left = new OrderedStack(new List<CrateStack>());
        var right = new OrderedStack(new List<CrateStack>());
        (left == right).Should().Be(true);
    }
}
