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
        return counter.Count();
    }

    private int Count()
    {
        _visibilities.SetBorderValues(true);
        
        MarkVisible();

        return _visibilities.ToEnumerable().Count(isVisible => isVisible);
    }

    private void MarkVisible()
    {
        var gridWidthHeight = _visibilities.Rows;
        
        if (gridWidthHeight <= 2) return;
        
        for (var row = 1; row < gridWidthHeight - 1; row++)
        {
            for (var col = 1; col < gridWidthHeight - 1; col++)
            {
                var isVisible = _visibilities.GetValue(row, col);
                
                isVisible = isVisible || _heights.GetValue(row - 1, col) < _heights.GetValue(row, col);
                isVisible = isVisible || _heights.GetValue(row, col - 1) < _heights.GetValue(row, col);
                _visibilities.SetValue(row, col, isVisible);
            }
        }
    }
}