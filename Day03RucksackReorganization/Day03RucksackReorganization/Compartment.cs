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
    }

    private bool Equals(Compartment other)
    {
        return Items.SequenceEqual(other.Items);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Compartment) obj);
    }

    public override int GetHashCode()
    {
        // TODO: Implement GetHashCode - e.g. see https://thomaslevesque.com/2020/05/15/things-every-csharp-developer-should-know-1-hash-codes/
        return Items.GetHashCode();
    }

    public static bool operator ==(Compartment? left, Compartment? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Compartment? left, Compartment? right)
    {
        return !Equals(left, right);
    }
}