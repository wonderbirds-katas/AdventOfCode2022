using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class StockSpecificationDeserializer
{
    public static OrderedStock Deserialize(string[] input)
    {
        var builder = OrderedStockBuilder.WithNumberOfStacks(1);
        
        for (var row = input.Length - 1; row >= 0; row--)
        {
            if (input[row][0] == '[')
            {
                var crate = input[row][1];
                builder.AddCratesToStack(new[] {crate}, 0);
            }    
        }
        
        return builder.Build();
    }
}