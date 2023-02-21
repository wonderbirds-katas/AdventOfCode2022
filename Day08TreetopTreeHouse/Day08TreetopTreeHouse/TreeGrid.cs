namespace Day08TreetopTreeHouse;

public static class TreeGrid
{
    public static Matrix<Tree> FromList(IList<string> treeHeightGrid) =>
        Matrix<Tree>.FromList(
            treeHeightGrid,
            digit => new Tree(int.Parse(digit), false, 0)
        );
}