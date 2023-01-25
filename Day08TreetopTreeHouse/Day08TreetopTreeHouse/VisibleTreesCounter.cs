namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(string[] treeHeightGrid)
    {
        var treeHeights = Matrix<int>.FromList(treeHeightGrid.ToList());
        var isVisible = new Matrix<bool>(treeHeights.Rows, treeHeights.Cols);
        
        return CountVisibleFromLeft(treeHeightGrid) 
               + CountVisibleFromTop(treeHeightGrid) 
               + CountVisibleFromRight(treeHeightGrid) 
               + CountVisibleFromBottom(treeHeightGrid);
    }

    private static int CountVisibleFromLeft(IEnumerable<IEnumerable<char>> treeHeightGrid) =>
        treeHeightGrid
            .Select(FromLeftCounter.Count)
            .Sum();

    private static int CountVisibleFromTop(IEnumerable<IEnumerable<char>> originalGrid)
        => CountVisibleFromLeft(originalGrid.Transpose());

    private static int CountVisibleFromRight(IEnumerable<IEnumerable<char>> originalGrid)
        => CountVisibleFromLeft(originalGrid.ReverseRowsAndColumns());

    private static int CountVisibleFromBottom(IEnumerable<IEnumerable<char>> originalGrid)
        => CountVisibleFromLeft(originalGrid.ReverseRowsAndColumns().Transpose());

    private static IEnumerable<IEnumerable<char>> ReverseRowsAndColumns(this IEnumerable<IEnumerable<char>> originalGrid)
        => originalGrid.Select(Enumerable.Reverse).Reverse();
}