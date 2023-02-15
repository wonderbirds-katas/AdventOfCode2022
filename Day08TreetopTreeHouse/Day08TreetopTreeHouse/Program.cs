namespace Day08TreetopTreeHouse;

public static class Program
{
    /// <summary>
    /// Advent of Code, Day 8: Treetop Tree House.
    /// </summary>
    /// <param name="file">File containing the grid of trees.</param>
    public static void Main(FileInfo file)
    {
        Console.WriteLine(VisibleTreesCounter.Count(File.ReadAllLines(file.FullName)));
    }
}
