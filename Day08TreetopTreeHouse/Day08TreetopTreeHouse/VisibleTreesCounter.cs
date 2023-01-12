namespace Day08TreetopTreeHouse;

public static class VisibleTreesCounter
{
    public static int CountTreesVisibleFromLeft(IList<string> treeHeightGrid)
    {
        if (treeHeightGrid.Any())
        {
            return 1;
        }
        return 0;
    }
}