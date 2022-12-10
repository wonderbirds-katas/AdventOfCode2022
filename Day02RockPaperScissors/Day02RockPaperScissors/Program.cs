namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var sum = File.ReadAllLines(args[0])
            .Parse(new LineParser())
            .Select(x => Turn.Score(x.Item1, x.Item2))
            .Sum(x => x.Sum);
        Console.WriteLine(sum);
    }
}