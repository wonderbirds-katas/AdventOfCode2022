namespace Day01CountCalories;

public static class Parser
{
    public static IEnumerable<int> Parse(IEnumerable<string> input)
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
