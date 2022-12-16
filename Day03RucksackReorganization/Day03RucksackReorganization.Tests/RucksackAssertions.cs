namespace Day03RucksackReorganization.Tests;

public static class RucksackAssertions
{
    public static void Equal(Rucksack expected, Rucksack actual)
    {
        Assert.Equal(expected.FirstCompartment.Items, actual.FirstCompartment.Items);
        Assert.Equal(expected.SecondCompartment.Items, actual.SecondCompartment.Items);
    }
}