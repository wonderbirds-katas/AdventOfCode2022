namespace Day01CountCalories;

public static class Processor
{
    public static int Process(int numberOfElves, IEnumerable<string> input)
    {
        var calorieSumsDescending = Parser.Parse(input);
        return Query.SumOfElves(numberOfElves, calorieSumsDescending);
    }
}
