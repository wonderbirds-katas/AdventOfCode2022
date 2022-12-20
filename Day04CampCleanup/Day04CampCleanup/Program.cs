namespace Day04CampCleanup;

public static class Program
{
    public static void Main(string[] args)
    {
        var count = File.ReadAllLines(args[0])
            .Parse()
            .Count(elfPair => elfPair.IsOneSectionFullyContained());

        Console.WriteLine($"{count}");
    }
}