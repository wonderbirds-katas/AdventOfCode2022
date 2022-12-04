namespace AdventOfCode202201;

public static class Query
{
    public static int SumOfElves(int numberOfElves, IEnumerable<int> caloriesSumDescending)
    {
        return caloriesSumDescending.Take(numberOfElves).Sum();
    }
}