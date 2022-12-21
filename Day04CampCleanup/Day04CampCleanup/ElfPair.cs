namespace Day04CampCleanup;

public class ElfPair
{
    public int[] FirstElfSections { get; }
    public int[] SecondElfSections { get; }

    public ElfPair(int[] firstElfSections, int[] secondElfSections)
    {
        FirstElfSections = firstElfSections;
        SecondElfSections = secondElfSections;
    }

    public bool IsOneSectionFullyContained() => FirstElfSections.Intersect(SecondElfSections).Any();
}