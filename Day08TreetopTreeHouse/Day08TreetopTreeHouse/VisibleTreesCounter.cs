namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int CountTreesVisibleFromLeft(IList<string> treeHeightGrid)
    {
        if (treeHeightGrid.Any())
        {
            var treeHeights = ParseTreeHeightString(treeHeightGrid[0]);
            var count = CountTreesLargerThanLeftNeighbour(treeHeights);
            return 1 + count;
        }
        return 0;
    }

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
        
        if (next > highest)
        {
            count++;
            highest = next;
        }

        return (count, highest);
    }

    private static List<int> ParseTreeHeightString(string treeHeightString)
    {
        return treeHeightString.Select(c => int.Parse(c.ToString())).ToList();
    }
}