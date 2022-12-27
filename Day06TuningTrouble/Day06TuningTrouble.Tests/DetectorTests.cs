namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Theory]
    [InlineData("abcd", 4)]
    [InlineData("aabcd", 5)]
    [InlineData("aaabcd", 6)]
    public void RunTest(string input, int expected) => Detector.CountCharactersBeforeStartOfPacketMarker(input).Should().Be(expected);
}

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
