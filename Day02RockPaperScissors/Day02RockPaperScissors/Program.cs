namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Select(line => line.ParseShapes())
            .Select(shapes => Round.Score(shapes.Item1, shapes.Item2))
            .Sum(score => score.Sum);
        Console.WriteLine(sum);
    }
}