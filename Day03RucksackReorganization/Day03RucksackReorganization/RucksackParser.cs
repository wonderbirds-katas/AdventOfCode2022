namespace Day03RucksackReorganization;

public static class RucksackParser
{
    public static IEnumerable<Rucksack> Parse(this IEnumerable<string> lines)
    {
        return lines.Select(Parse);
    }
    
    public static Rucksack Parse(this string line)
    {
        var half = line.Length / 2;

        var result = new Rucksack();
        line.Take(half).AddTo(result.FirstCompartment);
        line.Skip(half).AddTo(result.SecondCompartment);

        return result;
    }

    private static void AddTo(this IEnumerable<char> itemTypes, Compartment compartment)
    {
        itemTypes.ToList().ForEach(itemType => compartment.Add(new Item(itemType)));
    }
}
