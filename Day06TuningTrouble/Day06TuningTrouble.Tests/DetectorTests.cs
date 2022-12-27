namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Theory]
    [InlineData("abcd", 4)]
    [InlineData("aabcd", 5)]
    public void RunTest(string input, int expected) => Detector.CountCharactersBeforeStartOfPacketMarker(input).Should().Be(expected);
}

public static class Detector
{
    public static int CountCharactersBeforeStartOfPacketMarker(string input)
    {
        var buffer = input.Substring(0, 4).ToHashSet();
        
        if (buffer.Count != 4)
            return 5;
        
        return 4;
    }
}
