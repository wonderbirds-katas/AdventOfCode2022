namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int CountTreesVisibleFromLeft(IList<string> treeHeightGrid)
    {
        if (treeHeightGrid.Any())
        {
            var treeHeights = treeHeightGrid[0].Select(c => int.Parse(c.ToString())).ToList();
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
}