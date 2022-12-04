namespace AdventOfCode202201;

public static class Parser
{
    public static int Parse(string[] input)
    {
        return input.Select(int.Parse).Sum();
    }
}
