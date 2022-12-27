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
        var offset = -1;
        bool detected;

        do
        {
            ++offset;
            detected = input.Substring(offset, 4).ToHashSet().Count == 4;
        } while (!detected);

        return 4 + offset;
    }
}
