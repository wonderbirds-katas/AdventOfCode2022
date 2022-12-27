namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Theory]
    [InlineData(4, "abcd", 4)]
    [InlineData(4, "aabcd", 5)]
    [InlineData(4, "aaabcd", 6)]
    [InlineData(5, "aaabcde", 7)]
    public void RunTest(int length, string input, int expected) => Detector.CountCharactersBeforeStartOfPacketMarker(length, input).Should().Be(expected);
}