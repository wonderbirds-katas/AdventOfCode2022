namespace Day02RockPaperScissors;

public static class Program
{
    public static void Main(string[] args)
    {
        var input = File.ReadAllLines(args[0]);
        var sum = new FileContentsParser(new LineParser())
            .Parse(input)
            .Select(x => Turn.Score(x.Item1, x.Item2))
            .Sum(x => x.Sum);
        Console.WriteLine(sum);
    }
}