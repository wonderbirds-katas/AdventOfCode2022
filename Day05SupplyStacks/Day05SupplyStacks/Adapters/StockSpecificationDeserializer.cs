using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class StockSpecificationDeserializer
{
    public static OrderedStock Deserialize(string[] input)
    {
        var builder = OrderedStockBuilder.WithNumberOfStacks(1);
        var reversedStacksInput = input.Reverse().Skip(1).ToList();

        reversedStacksInput.ForEach(line => builder.AddCratesToStack(new[] { line[1] }, 0));

        return builder.Build();
    }
}
