namespace Day03RucksackReorganization;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Sum(line => line.Parse().Analyze().Priority);
        Console.WriteLine($"{sum}");
    }

    private static Item Analyze(this Rucksack rucksack)
    {
        return new Item();
    }

    private static Rucksack Parse(this string line)
    {
        return new Rucksack();
    }

    private class Rucksack
    {
    }

    private class Item
    {
        public int Priority => 1;
    }
}