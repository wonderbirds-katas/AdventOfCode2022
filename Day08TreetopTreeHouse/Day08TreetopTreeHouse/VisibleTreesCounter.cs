namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int Count(string[] treeHeightGrid)
    {
        temp_fixName_VisibleTreesCounter.Count(treeHeightGrid);
        
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

public class temp_fixName_VisibleTreesCounter
{
    private readonly Matrix<int> _heights;
    private readonly Matrix<bool> _visibilities;

    private temp_fixName_VisibleTreesCounter(string[] treeHeightGrid)
    {
        _heights = Matrix<int>.FromList(treeHeightGrid.ToList());
        _visibilities = new Matrix<bool>(_heights.Rows, _heights.Cols);
    }

    public static int Count(string[] treeHeightGrid)
    {
        var counter = new temp_fixName_VisibleTreesCounter(treeHeightGrid);
        
        return 0;
    }
}