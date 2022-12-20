namespace Day04CampCleanup;

public static class ElfPairParser
{
    public static IEnumerable<ElfPair> Parse(this IEnumerable<string> lines)
    {
        return lines.Select(Parse);
    }

    public static ElfPair Parse(this string line)
    {
        var ranges = line.Split(',');

        var first = int.Parse(ranges[0].Split('-')[0]);
        var second = int.Parse(ranges[1].Split('-')[0]);
        
        return new ElfPair(new []{ first }, new []{ second });
    }
}