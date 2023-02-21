namespace Day08TreetopTreeHouse;

public class VisibleTreesCounter
{
    private readonly Matrix<Tree> _trees;

    private VisibleTreesCounter(IEnumerable<string> treeHeightGrid)
    {
        _trees = TreeGrid.FromList(treeHeightGrid.ToList());
    }

    private VisibleTreesCounter(Matrix<Tree> trees)
    {
        _trees = trees;
    }

    public static int Count(Matrix<Tree> trees)
    {
        return new VisibleTreesCounter(trees).Count();
    }
    
    private int Count()
    {
        _trees.TransformBorderValues(tree => tree with {IsVisible = true});

        MarkVisibleInnerTrees();

        //_trees.PrintColorized(tree => tree.IsVisible, tree => tree.Height.ToString());

        return _trees.ToEnumerable().Count(tree => tree.IsVisible);
    }

    private void MarkVisibleInnerTrees()
    {
        if (_trees.Rows <= 2 || _trees.Cols <= 2)
            return;

        // MarkTreesVisibleFromTop
        MarkInnerTreesVisible(_trees.EnumerateByColumn(), false, false);

        // MarkTreesVisibleFromBottom
        MarkInnerTreesVisible(_trees.EnumerateByColumn().Select(col => col.Reverse()), false, true);

        // MarkTreesVisibleFromLeft
        MarkInnerTreesVisible(_trees.EnumerateByRow(), true, false);

        // MarkTreesVisibleFromRight
        MarkInnerTreesVisible(_trees.EnumerateByRow().Select(row => row.Reverse()), true, true);
    }

    private void MarkInnerTreesVisible(
        IEnumerable<IEnumerable<Tree>> rows,
        bool outerDimensionIsRows,
        bool innerDimensionIsReversed
    )
    {
        foreach (
            var dimension1Iter in rows.Select((dimension2, index) => new {dimension2, index})
        )
        {
            var largest = dimension1Iter.dimension2.First().Height;
            foreach (
                var dimension2Iter in dimension1Iter.dimension2
                    .Select((tree, index) => new {height = tree.Height, index})
                    .Skip(1)
            )
                if (dimension2Iter.height > largest)
                {
                    var inner = dimension2Iter.index;
                    if (innerDimensionIsReversed) inner = dimension1Iter.dimension2.Count() - 1 - inner;

                    var row = dimension1Iter.index;
                    var col = inner;
                    if (!outerDimensionIsRows) (row, col) = (col, row);

                    _trees.SetValue(row, col, new Tree(dimension2Iter.height, true, 0));
                    largest = dimension2Iter.height;
                }
        }
    }
}