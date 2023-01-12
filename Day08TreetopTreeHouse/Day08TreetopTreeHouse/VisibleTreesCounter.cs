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
        var count = 0;
        var previous = treeHeights[0];
        foreach (var next in treeHeights.Skip(1))
        {
            if (next > previous)
            {
                count++;
            }
        }

        return count;
    }

    private static List<int> ParseTreeHeightString(string treeHeightString)
    {
        return treeHeightString.Select(c => int.Parse(c.ToString())).ToList();
    }
}