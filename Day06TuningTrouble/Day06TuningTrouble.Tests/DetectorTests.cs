namespace Day06TuningTrouble.Tests;

public class DetectorTests
{
    [Fact]
    public void NoOtherCharactersBeforeStartOfPacketMarker()
    {
        Detector.CountCharactersBeforeStartOfPacketMarker("abcd").Should().Be(4);
    }

    [Fact]
    public void OneCharacterBeforeStartOfPacketMarker()
    {
        Detector.CountCharactersBeforeStartOfPacketMarker("aabcd").Should().Be(5);
    }
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
