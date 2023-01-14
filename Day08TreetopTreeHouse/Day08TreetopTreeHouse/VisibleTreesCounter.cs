namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int CountTreesVisibleFromLeft(IEnumerable<string> treeHeightGrid)
    {
        return treeHeightGrid
            .Select(CountTreesInRowVisibleFromLeft)
            .Sum();
    }

    private static int CountTreesInRowVisibleFromLeft(string treeHeightRowString)
    {
        var treeHeights = ParseTreeHeightString(treeHeightRowString);
        var count = CountTreesLargerThanLeftNeighbour(treeHeights);

        return 1 + count;
    }

    private static IList<int> ParseTreeHeightString(string treeHeightString)
        => treeHeightString.Select(c => int.Parse(c.ToString())).ToList();

    private static int CountTreesLargerThanLeftNeighbour(IList<int> treeHeights)
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