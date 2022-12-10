namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Sum(line => line.ParsePart2().CalculateRound().Score().Sum);
        Console.WriteLine(sum);
    }
}