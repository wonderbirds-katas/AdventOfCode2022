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

        var firstRange = StringToRange(ranges[0]).ToArray();
        var secondRange = StringToRange(ranges[1]).ToArray();

        return new ElfPair(firstRange, secondRange);
    }

    private static IEnumerable<int> StringToRange(string range)
    {
        var intervalBoundaries = range.Split('-').Select(int.Parse).ToArray();
        var start = intervalBoundaries[0];
        var count = intervalBoundaries[1] - start + 1;
        
        return Enumerable.Range(start, count);
    }
}