namespace Day03RucksackReorganization;

public class Rucksack
{
    public List<Item> Items { get; } = new();

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public override string ToString() =>
        $"{{{string.Join(", ", Items.Select(item => item.Type))}}}";
}
