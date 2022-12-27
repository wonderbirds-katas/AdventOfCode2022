namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Fact]
    public void NoOtherCharactersBeforeStartOfPacketMarker()
    {
        Detector.CountCharactersBeforeStartOfPacketMarker("abcd").Should().Be(4);
    }
}

public static class Detector
{
    public static int CountCharactersBeforeStartOfPacketMarker(string input)
    {
        return 4;
    }
}
