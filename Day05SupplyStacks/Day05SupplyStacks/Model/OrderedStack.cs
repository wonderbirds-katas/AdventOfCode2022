namespace Day05SupplyStacks.Model;

public class OrderedStack
{
    public List<CrateStack> CrateStacks { get; }

    public OrderedStack(List<CrateStack> crateStacks)
    {
        CrateStacks = crateStacks;
    }
}