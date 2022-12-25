using System.Text.RegularExpressions;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class RearrangementProcedureDeserializer
{
    public static RearrangementProcedure Deserialize(IEnumerable<string> input)
    {
        var result = new RearrangementProcedure();

        input.Select(Parse).ToList().ForEach(step => result.Add(step));

        return result;
    }

    private static RearrangementStep Parse(string line)
    {
        var matches = Regex.Matches(line, @"move (\d+) from (\d+) to (\d+)");
        var matchGroupStrings = matches.SelectMany(
            o => o.Groups.Cast<Capture>().Skip(1).Select(c => c.Value)
        );
        var matchGroupValues = matchGroupStrings.Select(int.Parse).ToArray();
        var step = new RearrangementStep(
            matchGroupValues[0],
            matchGroupValues[1] - 1,
            matchGroupValues[2] - 1
        );
        return step;
    }
}
