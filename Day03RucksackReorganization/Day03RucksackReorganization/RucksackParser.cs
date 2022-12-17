namespace Day03RucksackReorganization;

public static class RucksackParser
{
    public static Rucksack Parse(this string line)
    {
        var result = new Rucksack();

        if (line == "") return result;

        var halfLineLength = line.Length / 2;
        for (var index = 0; index < halfLineLength; index++)
        {
            var firstItemType = line[index];
            result.FirstCompartment.Add(new Item(firstItemType));

            var secondItemType = line[halfLineLength + index];
            result.SecondCompartment.Add(new Item(secondItemType));
        }

        return result;
    }
}
