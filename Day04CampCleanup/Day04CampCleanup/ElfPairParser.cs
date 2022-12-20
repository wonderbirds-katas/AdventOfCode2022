namespace Day04CampCleanup;

public static class ElfPairParser
{
    public static IEnumerable<ElfPair> Parse(this IEnumerable<string> lines)
    {
        return lines.Select(Parse);
    }

    public static ElfPair Parse(this string line)
    {
        return new ElfPair(new []{ 1 }, new []{ 2 });
    }
}