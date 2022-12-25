namespace Day05SupplyStacks.Model;

public class OrderedStockBuilder
{
    private readonly List<CrateStack> _stacks;

    private OrderedStockBuilder(int numberOfStacks)
    {
        _stacks = Enumerable.Range(0, numberOfStacks).Select(_ => new CrateStack()).ToList();
    }
    
    public OrderedStockBuilder AddCrateToStack(char crate, int stackIndex)
    {
        _stacks[stackIndex].AddOnTop(crate);
        return this;
    }

    public OrderedStockBuilder AddCratesToStack(IEnumerable<char> crates, int stackIndex)
    {
        crates.ToList().ForEach(crate => AddCrateToStack(crate, stackIndex));

        return this;
    }

    public OrderedStock Build() => new(_stacks);

    public static OrderedStockBuilder WithNumberOfStacks(int numberOfStacks) => new(numberOfStacks);
}
