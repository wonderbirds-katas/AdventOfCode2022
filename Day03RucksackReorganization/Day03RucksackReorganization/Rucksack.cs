namespace Day03RucksackReorganization;

public class Rucksack
{
    public IEnumerable<Item> Items { get; } = new List<Item>();

    public override string ToString() =>
        $"{{{string.Join(", ", Items.Select(item => item.Type))}}}";
}
