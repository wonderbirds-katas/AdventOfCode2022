namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Theory]
    [InlineData("abcd", 4)]
    [InlineData("aabcd", 5)]
    [InlineData("aaabcd", 6)]
    public void RunTest(string input, int expected) => Detector.CountCharactersBeforeStartOfPacketMarker(input).Should().Be(expected);
}