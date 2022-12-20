namespace Day03RucksackReorganization;

public static class RucksackParser
{
    public static IEnumerable<Rucksack> Parse(this IEnumerable<string> lines)
    {
        return lines.Select(Parse);
    }
    
    public static Rucksack Parse(this string line)
    {
        var result = new Rucksack();

        line.ToList().ForEach(itemType => result.Add(new Item(itemType)));

        return result;
    }
}
