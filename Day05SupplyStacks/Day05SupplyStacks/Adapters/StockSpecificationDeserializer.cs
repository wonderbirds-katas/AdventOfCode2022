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

        foreach (var line in reversedStacksInput)
        {
            for (var stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
            {
                var crate = line.CrateForStack(stackIndex);
                AddCrateIfDefined(crate, builder, stackIndex);
            }
        }

        return builder.Build();
    }

    private static void AddCrateIfDefined(char? crate, OrderedStockBuilder builder, int stackIndex)
    {
        if (crate.HasValue)
        {
            builder.AddCratesToStack(new[] {crate.Value}, stackIndex);
        }
    }

    private static char? CrateForStack(this string line, int stackIndex)
    {
        int[] cratePositionInLine = { 1, 5, 9, 13, 17, 21, 25, 29, 33 };
        var crateOrEmpty = line[cratePositionInLine[stackIndex]];
        char? crate = crateOrEmpty != ' ' ? crateOrEmpty : null;
        return crate;
    }
}
