using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class OrderedStackEqualityTests
{
    [Fact]
    public void Empty()
    {
        var left = new OrderedStock(new List<CrateStack>());
        var right = new OrderedStock(new List<CrateStack>());
        (left == right).Should().Be(true);
    }
}
