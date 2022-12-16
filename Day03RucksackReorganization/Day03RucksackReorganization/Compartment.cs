namespace Day03RucksackReorganization;

public class Compartment
{
    public List<Item> Items { get; }

    public Compartment()
    {
        Items = new List<Item>();
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }
}