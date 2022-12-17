namespace Day03RucksackReorganization;

public static class RucksackParser
{
    public static Rucksack Parse(this string line)
    {
        var result = new Rucksack();

        if (line == "") return result;

        var firstItemType = line[0];
        result.FirstCompartment.Add(new Item(firstItemType));

        var secondItemType = line[1];
        result.SecondCompartment.Add(new Item(secondItemType));

        return result;
    }
}
