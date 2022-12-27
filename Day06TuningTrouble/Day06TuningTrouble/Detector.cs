namespace Day06TuningTrouble;
using MoreLinq;

public static class Detector
{
    public static int CountCharactersBeforeMarkerWithLength(int length, string input) =>
        input.AsEnumerable().Window(length).TakeWhile(SomeAreSame).Count() + length;

    private static bool SomeAreSame(IList<char> characters) =>
        characters.ToHashSet().Count < characters.Count;
}
