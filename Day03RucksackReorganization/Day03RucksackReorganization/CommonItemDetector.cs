namespace Day03RucksackReorganization;

public static class CommonItemDetector
{
    public static IEnumerable<Item> Analyze(this IEnumerable<Group> groups) => groups.Select(Analyze);

    public static Item Analyze(Group group) => group.Rucksacks.Aggregate(Intersect).Items.First();

    private static Rucksack Intersect(Rucksack first, Rucksack second) => new(first.Items.Intersect(second.Items));
}