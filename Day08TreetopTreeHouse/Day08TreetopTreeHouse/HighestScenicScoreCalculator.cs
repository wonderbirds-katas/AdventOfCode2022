namespace Day08TreetopTreeHouse;

public static class HighestScenicScoreCalculator
{
    public static int Calculate(Matrix<Tree> treeHeights)
    {
        if (treeHeights.Cols <= 2 || treeHeights.Rows <= 2)
        {
            return 0;
        }
        return 1;
    }
}