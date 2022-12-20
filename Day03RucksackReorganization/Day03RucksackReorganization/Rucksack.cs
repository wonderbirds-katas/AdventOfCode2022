using System.Runtime.CompilerServices;

namespace Day03RucksackReorganization;

public class Rucksack
{
    public List<Item> Items { get; } = new();

    public Rucksack()
    {
    }
    
    public Rucksack(IEnumerable<Item> items)
    {
        Items.AddRange(items);
    }
    
    public override string ToString() =>
        $"{{{string.Join(", ", Items.Select(item => item.Type))}}}";
}
