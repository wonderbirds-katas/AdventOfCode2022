namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int CountTreesVisibleFromLeft(IList<string> treeHeightGrid)
    {
        if (treeHeightGrid.Any())
        {
            var treeHeights = ParseTreeHeightString(treeHeightGrid[0]);
            var count = 1;
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
        return 0;
    }

    private static List<int> ParseTreeHeightString(string treeHeightString)
    {
        return treeHeightString.Select(c => int.Parse(c.ToString())).ToList();
    }
}