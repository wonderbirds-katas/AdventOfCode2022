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

    public bool IsOneSectionFullyContained()
    {
        // TODO: Algorithm is easy to understand, but performance could be better!
        var intersection = FirstElfSections.Intersect(SecondElfSections).ToList();
        
        return intersection.SequenceEqual(FirstElfSections) ||
               intersection.SequenceEqual(SecondElfSections);
    }
}