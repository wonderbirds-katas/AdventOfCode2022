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

    // Note:
    // The Algorithm is easy to understand, but its performance could be better.
    // However, I will not optimize prematurely and sacrifice readability.
    public bool IsOneSectionFullyContained()
    {
        var intersection = FirstElfSections.Intersect(SecondElfSections).ToList();
        
        return intersection.SequenceEqual(FirstElfSections) ||
               intersection.SequenceEqual(SecondElfSections);
    }
}