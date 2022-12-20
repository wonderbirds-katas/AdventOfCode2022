namespace Day04CampCleanup;

public class ElfPair
{
    private readonly int[] _firstElfSections;
    private readonly int[] _secondElfSections;

    public ElfPair(int[] firstElfSections, int[] secondElfSections)
    {
        _firstElfSections = firstElfSections;
        _secondElfSections = secondElfSections;
    }

    public bool IsOneSectionFullyContained()
    {
        // TODO: Algorithm is easy to understand, but performance could be better!
        var intersection = _firstElfSections.Intersect(_secondElfSections).ToList();
        
        return intersection.SequenceEqual(_firstElfSections) ||
               intersection.SequenceEqual(_secondElfSections);
    }
}