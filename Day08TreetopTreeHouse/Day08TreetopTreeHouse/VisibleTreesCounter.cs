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
        
        MarkVisibleInnerTrees();

        return _visibilities.ToEnumerable().Count(isVisible => isVisible);
    }

    private void MarkVisibleInnerTrees()
    {
        var rows = _visibilities.Rows;
        var cols = _visibilities.Cols;
        
        if (rows <= 2 || cols <= 2) return;

        // MarkTreesVisibleFromTop
        var columns = _heights.EnumerateByColumn().ToList();
        foreach (var columnIter in columns.Select((column, index) => new {column, index}))
        {
            var largest = columnIter.column.First();
            foreach (var rowIter in columnIter.column.Select((height, index) => new { height, index }).Skip(1))
            {
                if (rowIter.height > largest)
                {
                    _visibilities.SetValue(rowIter.index, columnIter.index, true);
                    largest = rowIter.height;
                }
            }
        }

        // MarkTreesVisibleFromBottom
        columns = _heights.EnumerateByColumn().Select(col => col.Reverse()).ToList();
        foreach (var columnIter in columns.Select((column, index) => new {column, index}))
        {
            var largest = columnIter.column.First();
            foreach (var rowIter in columnIter.column.Select((height, index) => new { height, index }).Skip(1))
            {
                if (rowIter.height > largest)
                {
                    _visibilities.SetValue(rowIter.index, columnIter.index, true);
                    largest = rowIter.height;
                }
            }
        }
        
        // MarkTreesVisibleFromLeft
        for (var row = 1; row < rows - 1; row++)
        {
            var largest = _heights.GetValue(row, 0);
            for (var col = 1; col < cols - 1; col++)
            {
                var current = _heights.GetValue(row, col);
                
                if (current > largest)
                {
                    _visibilities.SetValue(row, col, true);
                    largest = current;
                }
            }
        }

        // MarkTreesVisibleFromRight
        for (var row = 1; row < rows - 1; row++)
        {
            var largest = _heights.GetValue(row, rows - 1);
            for (var col = cols - 2; col > 0; col--)
            {
                var current = _heights.GetValue(row, col);
                
                if (current > largest)
                {
                    _visibilities.SetValue(row, col, true);
                    largest = current;
                }
            }
        }
    }
}
