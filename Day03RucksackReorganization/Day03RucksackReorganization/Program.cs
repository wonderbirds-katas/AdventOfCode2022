namespace Day03RucksackReorganization;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0]).Sum(line => line.Parse().Analyze().Priority);
        Console.WriteLine($"{sum}");
    }
}
