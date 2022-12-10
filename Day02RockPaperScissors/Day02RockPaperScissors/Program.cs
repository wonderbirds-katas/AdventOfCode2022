namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Sum(line => line.Parse().Score().Sum);
        Console.WriteLine(sum);
    }
}