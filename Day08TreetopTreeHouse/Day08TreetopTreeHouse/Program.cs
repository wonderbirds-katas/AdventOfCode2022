namespace Day08TreetopTreeHouse;

public static class Program
{
    public static void Main(string[] args)
    {
        var numberOfVisibleTrees = VisibleTreesCounter.Count(File.ReadAllLines(args[0]));
        Console.WriteLine(numberOfVisibleTrees);
    }
}
