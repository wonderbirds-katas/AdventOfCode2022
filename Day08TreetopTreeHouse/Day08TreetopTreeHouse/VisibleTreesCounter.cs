namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(IEnumerable<string> treeHeightGrid)
    {
        var originalGrid = treeHeightGrid.ToList();

        return CountVisibleFromLeft(originalGrid) 
               + CountVisibleFromTop(originalGrid) 
               + CountVisibleFromRight(originalGrid) 
               + CountVisibleFromBottom(originalGrid);
    }

    private static int CountVisibleFromTop(List<string> originalGrid)
    {
        var turned270degrees = Transposer.Transpose(originalGrid.Select(Enumerable.Reverse).ToList());
        var fromTop = CountVisibleFromLeft(turned270degrees);
        return fromTop;
    }

    private static int CountVisibleFromRight(List<string> originalGrid)
    {
        var fromRight = CountVisibleFromLeft(originalGrid.Select(Enumerable.Reverse).ToList());
        return fromRight;
    }

    private static int CountVisibleFromLeft(IEnumerable<IEnumerable<char>> treeHeightGrid) =>
        treeHeightGrid
            .Select(FromLeftCounter.Count)
            .Sum();

    private static int CountVisibleFromBottom(IEnumerable<string> originalGrid)
    {
        var fromBottomInput = originalGrid.ReverseRowsAndColumns().Transpose();
        return CountVisibleFromLeft(fromBottomInput);
    }

    private static IEnumerable<IEnumerable<char>> ReverseRowsAndColumns(this IEnumerable<string> originalGrid)
        => originalGrid.Select(Enumerable.Reverse).Reverse();
}