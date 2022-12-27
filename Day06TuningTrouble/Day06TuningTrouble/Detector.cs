namespace Day06TuningTrouble;
using MoreLinq;

public static class Detector
{
    private const int StartOfPacketMarkerLength = 4;

    public static int CountCharactersBeforeStartOfPacketMarker(string input) =>
        input
            .AsEnumerable()
            .Window(StartOfPacketMarkerLength)
            .TakeWhile(SomeAreSame)
            .Count() + StartOfPacketMarkerLength;

    private static bool SomeAreSame(IList<char> characters) => characters.ToHashSet().Count < StartOfPacketMarkerLength;
}
