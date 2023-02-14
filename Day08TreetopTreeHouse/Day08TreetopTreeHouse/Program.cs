namespace Day08TreetopTreeHouse;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(VisibleTreesCounter.Count(File.ReadAllLines(args[0])));
    }
}
