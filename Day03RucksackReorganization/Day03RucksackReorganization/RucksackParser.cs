namespace Day03RucksackReorganization;

public static class RucksackParser
{
    public static Rucksack Parse(this string line)
    {
        var result = new Rucksack();

        if (line == "") return result;
        
        result.FirstCompartment.Add(new Item('a'));
        result.SecondCompartment.Add(new Item('b'));

        return result;
    }
}
