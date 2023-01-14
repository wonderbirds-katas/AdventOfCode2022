namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(IEnumerable<string> treeHeightGrid)
    {
        var originalGrid = treeHeightGrid.ToList();
        var fromLeft = CountVisibleFromLeft(originalGrid);

        var turned180degrees = originalGrid.Select(Enumerable.Reverse).ToList();
        var fromRight = CountVisibleFromLeft(turned180degrees);

        var turned270degrees = Transposer.Transpose(turned180degrees);
        var fromTop = CountVisibleFromLeft(turned270degrees);
        
        return fromLeft + fromTop + fromRight;
    }

    private static int CountVisibleFromLeft(IEnumerable<IEnumerable<char>> treeHeightGrid) =>
        treeHeightGrid
            .Select(FromLeftCounter.Count)
            .Sum();
}