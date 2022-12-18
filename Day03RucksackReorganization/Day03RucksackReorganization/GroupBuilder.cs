namespace Day03RucksackReorganization;

public static class GroupBuilder
{
    private const int RucksacksPerGroup = 3;

    public static IEnumerable<Group> Group(this IEnumerable<Rucksack> rucksacks) =>
        rucksacks
            .Select((value, index) => new { GroupIndex = index / RucksacksPerGroup, value })
            .GroupBy(pair => pair.GroupIndex)
            .Select(grouping => new Group(grouping.Select(p => p.value)));
}
