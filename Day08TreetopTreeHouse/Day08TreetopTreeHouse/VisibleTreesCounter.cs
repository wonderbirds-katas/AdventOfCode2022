namespace Day08TreetopTreeHouse;

public class VisibleTreesCounter
{
    private readonly Matrix<Tree> _trees;

    private VisibleTreesCounter(string[] treeHeightGrid)
    {
        _trees = Matrix<Tree>.FromList(treeHeightGrid.ToList(), s => new Tree(int.Parse(s), false));
    }

    public static int Count(string[] treeHeightGrid)
    {
        var counter = new VisibleTreesCounter(treeHeightGrid);
        return counter.Count();
    }

    private int Count()
    {
        _trees.TransformBorderValues(tree => new Tree(tree.Height, true));

        MarkVisibleInnerTrees();

        return _trees.ToEnumerable().Count(tree => tree.IsVisible);
    }

    private void MarkVisibleInnerTrees()
    {
        if (_trees.Rows <= 2 || _trees.Cols <= 2) return;

        // MarkTreesVisibleFromTop
        MarkInnerTreesVisibleFromTop(_trees.EnumerateByColumn());

        // MarkTreesVisibleFromBottom
        MarkInnerTreesVisibleFromTop(_trees.EnumerateByColumn().Select(col => col.Reverse()));
        
        // MarkTreesVisibleFromLeft
        MarkInnerTreesVisibleFromLeft(_trees.EnumerateByRow());

        // MarkTreesVisibleFromRight
        MarkInnerTreesVisibleFromLeft(_trees.EnumerateByRow().Select(row => row.Reverse()));
    }

    private void MarkInnerTreesVisibleFromTop(IEnumerable<IEnumerable<Tree>> columns)
    {
        foreach (var dimension1Iter in columns.Select((dimension2, index) => new {dimension2, index}))
        {
            var largest = dimension1Iter.dimension2.First().Height;
            foreach (var dimension2Iter in dimension1Iter.dimension2
                         .Select((tree, index) => new {height = tree.Height, index}).Skip(1))
            {
                if (dimension2Iter.height > largest)
                {
                    _trees.SetValue(dimension2Iter.index, dimension1Iter.index, new Tree(dimension2Iter.height, true));
                    largest = dimension2Iter.height;
                }
            }
        }
    }

    private void MarkInnerTreesVisibleFromLeft(IEnumerable<IEnumerable<Tree>> rows)
    {
        foreach (var dimension1Iter in rows.Select((dimension2, index) => new {dimension2, index}))
        {
            var largest = dimension1Iter.dimension2.First().Height;
            foreach (var dimension2Iter in dimension1Iter.dimension2
                         .Select((tree, index) => new {height = tree.Height, index}).Skip(1))
            {
                if (dimension2Iter.height > largest)
                {
                    _trees.SetValue(dimension1Iter.index, dimension2Iter.index, new Tree(dimension2Iter.height, true));
                    largest = dimension2Iter.height;
                }
            }
        }
    }
}