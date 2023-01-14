namespace Day08TreetopTreeHouse;

public static class FromLeftCounter
{
    public static int Count(IEnumerable<char> treeHeightRowString)
    {
        var treeHeights = ParseTreeHeightString(treeHeightRowString);
        var count = Count(treeHeights);

        return 1 + count;
    }

    private static IList<int> ParseTreeHeightString(IEnumerable<char> treeHeightString)
        => treeHeightString.Select(c => int.Parse(c.ToString())).ToList();

    private static int Count(IList<int> treeHeights)
    {
        var (count, _) = treeHeights
            .Skip(1)
            .Aggregate((0, treeHeights[0]), CountIfHighestAndUpdateHighest);
        return count;
    }

    private static (int count, int highest) CountIfHighestAndUpdateHighest((int count, int highest) accumulator, int next)
    {
        var (count, highest) = accumulator;
        
        if (next <= highest) return (count, highest);

        count++;
        highest = next;

        return (count, highest);
    }
}
