namespace AdventOfCode202201;

public class Elf
{
    public int SumCalories { get; private set; }

    public void AddCalories(int calories)
    {
        SumCalories += calories;
    }
}
