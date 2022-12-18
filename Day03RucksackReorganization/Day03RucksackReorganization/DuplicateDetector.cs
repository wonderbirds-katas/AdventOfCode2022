namespace Day03RucksackReorganization;

public static class DuplicateDetector
{
    public static Item Analyze(this Rucksack rucksack)
    {
        return rucksack.FirstCompartment.Items.Intersect(rucksack.SecondCompartment.Items).First();
    }
}