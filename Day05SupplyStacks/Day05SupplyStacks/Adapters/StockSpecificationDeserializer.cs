using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class StockSpecificationDeserializer
{
    public static OrderedStock Deserialize(IEnumerable<string> input)
    {
        var stackCountLine = input.Last().TrimEnd();
        var numberOfStacks = int.Parse(stackCountLine.Last().ToString());

        var builder = OrderedStockBuilder.WithNumberOfStacks(numberOfStacks);
        var reversedStacksInput = input.Reverse().Skip(1).ToList();

        foreach (var line in reversedStacksInput)
        {
            Enumerable
                .Range(0, numberOfStacks)
                .Select(i => new { Symbol = Symbol(line, i), StackIndex = i })
                .Where(p => p.Symbol != ' ')
                .ToList()
                .ForEach(p => builder.AddCrateToStack(p.Symbol, p.StackIndex));
        }

        return builder.Build();
    }

    private static char Symbol(string line, int stackIndex) => line[PositionOfSymbol(stackIndex)];

    private static int PositionOfSymbol(int stackIndex) => 1 + stackIndex * 4;
}
