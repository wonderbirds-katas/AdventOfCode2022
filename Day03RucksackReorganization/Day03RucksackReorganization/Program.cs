namespace Day03RucksackReorganization;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Parse()
            .Group()
            .Analyze()
            .Sum(item => item.Priority);
        Console.WriteLine($"{sum}");
    }
}
