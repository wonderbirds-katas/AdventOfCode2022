namespace Day08TreetopTreeHouse;

public static class Program
{
    /// <summary>
    /// Advent of Code, Day 8: Treetop Tree House.
    /// </summary>
    /// <param name="part">1 or 2 - select which part of the puzzle to solve</param>
    /// <param name="file">File containing the grid of trees.</param>
    public static void Main(int part, FileInfo file)
    {
        if (part == 1)
        {
            Console.WriteLine(VisibleTreesCounter.Count(File.ReadAllLines(file.FullName)));
        }
        else
        {
            var treeHeights = Matrix<int>.FromList(File.ReadAllLines(file.FullName).ToList());
            var scenicScores = ScenicScoreCalculator.Calculate(treeHeights);
            Console.WriteLine(scenicScores.ToEnumerable().Max());
        }
    }
}
