namespace Day06TuningTrouble;

public static class Detector
{
    public static int CountCharactersBeforeStartOfPacketMarker(string input)
    {
        const int startOfPacketMarkerLength = 4;
        
        var result = startOfPacketMarkerLength - 1;

        do
        {
            ++result;
        } while (!IsStartOfPacketMarker(input, result, startOfPacketMarkerLength));

        return result;
    }

    private static bool IsStartOfPacketMarker(string input, int startIndex, int startOfPacketMarkerLength) =>
        input
            .Substring(startIndex - startOfPacketMarkerLength, startOfPacketMarkerLength)
            .ToHashSet()
            .Count == startOfPacketMarkerLength;
}