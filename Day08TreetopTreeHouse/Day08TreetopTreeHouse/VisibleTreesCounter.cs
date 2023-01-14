namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(IEnumerable<string> treeHeightGrid)
    {
        var enumeratedGrid = treeHeightGrid.ToList();
        
        var fromLeft = enumeratedGrid
            .Select(FromLeftCounter.Count)
            .Sum();

        var fromRight = enumeratedGrid
            .Select(Enumerable.Reverse)
            .Select(FromLeftCounter.Count)
            .Sum();
        
        return fromLeft + fromRight;
    }
}