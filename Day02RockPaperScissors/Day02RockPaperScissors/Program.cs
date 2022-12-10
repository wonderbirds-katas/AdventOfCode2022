namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Select(line => line.ParseShapes())
            .Select(shapes => new Round(shapes.Item1, shapes.Item2).Score())
            .Sum(score => score.Sum);
        Console.WriteLine(sum);
    }
}