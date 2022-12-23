using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class OrderedStockBuilder
{
    private readonly List<CrateStack> _stacks;

    private OrderedStockBuilder(int numberOfStacks)
    {
        _stacks = Enumerable.Range(0, numberOfStacks).Select(_ => new CrateStack()).ToList();
    }

    public OrderedStock Build() => new(_stacks);

    public static OrderedStockBuilder WithNumberOfStacks(int numberOfStacks) => new(numberOfStacks);
}
