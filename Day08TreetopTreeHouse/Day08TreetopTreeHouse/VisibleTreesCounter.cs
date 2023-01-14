namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(IEnumerable<string> treeHeightGrid)
    {
        var originalGrid = treeHeightGrid.ToList();
        
        var fromLeft = originalGrid
            .Select(FromLeftCounter.Count)
            .Sum();

        var turned180degrees = originalGrid.Select(Enumerable.Reverse).ToList();
        var fromRight = turned180degrees
            .Select(FromLeftCounter.Count)
            .Sum();

        var turned270degrees = Transposer.Transpose(turned180degrees).ToList();
        var fromTop = turned270degrees
            .Select(FromLeftCounter.Count)
            .Sum();
        
        return fromLeft + fromTop + fromRight;
    }
}