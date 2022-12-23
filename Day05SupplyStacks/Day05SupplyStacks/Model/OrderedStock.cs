namespace Day05SupplyStacks.Model;

public class OrderedStock
{
    private readonly List<CrateStack> _crateStacks;

    public OrderedStock(List<CrateStack> crateStacks)
    {
        _crateStacks = crateStacks;
    }

    protected bool Equals(OrderedStock other)
    {
        return _crateStacks.SequenceEqual(other._crateStacks);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OrderedStock) obj);
    }

    public override int GetHashCode() => throw new NoHashCodeAvailableException(typeof(OrderedStock));

    public static bool operator ==(OrderedStock? left, OrderedStock? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(OrderedStock? left, OrderedStock? right)
    {
        return !Equals(left, right);
    }
}