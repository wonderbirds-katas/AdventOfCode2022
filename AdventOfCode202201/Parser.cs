namespace AdventOfCode202201;

public static class Parser
{
    public static int Parse(string[] input)
    {
        var calorieSums = new SortedSet<int>();
        var sum = 0;
        foreach (var caloriesString in input)
        {
            if (caloriesString == "")
            {
                calorieSums.Add(sum);
                sum = 0;
            }
            else
            {
                sum += int.Parse(caloriesString);
            }
        }
        calorieSums.Add(sum);
        return calorieSums.LastOrDefault();
    }
}
