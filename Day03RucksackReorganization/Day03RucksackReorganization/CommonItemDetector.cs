namespace Day03RucksackReorganization;

public static class CommonItemDetector
{
    public static IEnumerable<Item> Analyze(IEnumerable<Group> groups) => groups.Select(Analyze);

    public static Item Analyze(Group group) => new('a');
}