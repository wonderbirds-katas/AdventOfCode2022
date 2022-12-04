namespace AdventOfCode202201;

public static class Parser
{
    public static int Process(int numberOfElves, IEnumerable<string> input)
    {
        var calorieSumsDescending = Parse(input);
        return calorieSumsDescending.Take(numberOfElves).Sum();
    }

    private static IEnumerable<int> Parse(IEnumerable<string> input)
    {
        var calorieSumsAscending = new SortedSet<int>();
        var sum = 0;
        
        foreach (var caloriesString in input)
        {
            if (caloriesString == "")
            {
                calorieSumsAscending.Add(sum);
                sum = 0;
            }
            else
            {
                sum += int.Parse(caloriesString);
            }
        }

        calorieSumsAscending.Add(sum);
        
        return calorieSumsAscending.Reverse();
    }
}
