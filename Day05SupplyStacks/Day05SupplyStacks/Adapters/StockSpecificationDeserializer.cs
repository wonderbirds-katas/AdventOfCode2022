using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class StockSpecificationDeserializer
{
    public static OrderedStock Deserialize(string[] input)
    {
        var builder = OrderedStockBuilder.WithNumberOfStacks(1);
        
        if (input[0][0] == '[')
        {
            var crate = input[0][1];
            builder.AddCratesToStack(new[] {crate}, 0);
        }

        return builder.Build();
    }
}