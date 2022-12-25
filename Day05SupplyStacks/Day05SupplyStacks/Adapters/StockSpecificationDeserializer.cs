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
            Enumerable.Range(0, numberOfStacks)
                .Select(stackIndex => new { Symbol = line.SymbolForStack(stackIndex), StackIndex = stackIndex })
                .Where(p => p.Symbol != ' ')
                .ToList()
                .ForEach(pair => builder.AddCratesToStack(new []{pair.Symbol}, pair.StackIndex));
        }

        return builder.Build();
    }

    private static char SymbolForStack(this string line, int stackIndex)
    {
        int[] cratePositionInLine = { 1, 5, 9, 13, 17, 21, 25, 29, 33 };
        return line[cratePositionInLine[stackIndex]];
    }
}
