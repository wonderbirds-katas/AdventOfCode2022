namespace Day06TuningTrouble;

public static class Program
{
    public static void Main(string[] args)
    {
        var length = int.Parse(args[0]);
        var input = File.ReadAllText(args[1]);
        var result = Detector.CountCharactersBeforeStartOfPacketMarker(length, input);
        Console.WriteLine($"{result}");
    }
}
