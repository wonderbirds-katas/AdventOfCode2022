namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(IEnumerable<string> treeHeightGrid)
    {
        return treeHeightGrid
            .Select(FromLeftCounter.Count)
            .Sum();
    }
}