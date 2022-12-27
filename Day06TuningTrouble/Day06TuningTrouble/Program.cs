namespace Day06TuningTrouble;

public static class Program
{
    public static void Main(string[] args)
    {
        var input = File.ReadAllText(args[0]);
        var result = Detector.CountCharactersBeforeStartOfPacketMarker(input);
        Console.WriteLine($"{result}");
    }
}
