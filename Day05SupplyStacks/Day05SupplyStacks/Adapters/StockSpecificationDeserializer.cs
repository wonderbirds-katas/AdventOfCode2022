using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class StockSpecificationDeserializer
{
    public static OrderedStock Deserialize(string[] input)
    {
        var stackCountLine = input.Last().TrimEnd();
        var numberOfStacks = int.Parse(stackCountLine.Last().ToString());

        var builder = OrderedStockBuilder.WithNumberOfStacks(numberOfStacks);
        var reversedStacksInput = input.Reverse().Skip(1).ToList();

        int[] cratePositionInLine = { 1, 5, 9, 13, 17, 21, 25, 29, 33 };
        foreach (var line in reversedStacksInput)
        {
            for (var stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
            {
                var crateOrEmpty = line[cratePositionInLine[stackIndex]];
                if (crateOrEmpty != ' ')
                {
                    builder.AddCratesToStack(new[] { crateOrEmpty }, stackIndex);
                }
            }
        }

        return builder.Build();
    }
}
