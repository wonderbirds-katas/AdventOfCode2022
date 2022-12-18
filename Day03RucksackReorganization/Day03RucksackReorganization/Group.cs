namespace Day03RucksackReorganization;

public class Group
{
    public IEnumerable<Rucksack> Rucksacks { get; }

    public Group(IEnumerable<Rucksack> rucksacks) => Rucksacks = new List<Rucksack>(rucksacks);
}
