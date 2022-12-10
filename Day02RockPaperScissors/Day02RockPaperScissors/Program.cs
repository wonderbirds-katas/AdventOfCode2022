namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Select(line => line.ParseShapes().Score())
            .Sum(score => score.Sum);
        Console.WriteLine(sum);
    }
}