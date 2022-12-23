namespace Day05SupplyStacks.Model;

public class OrderedStack
{
    private readonly List<CrateStack> _crateStacks;

    public OrderedStack(List<CrateStack> crateStacks)
    {
        _crateStacks = crateStacks;
    }

    protected bool Equals(OrderedStack other)
    {
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OrderedStack) obj);
    }

    public override int GetHashCode() => throw new NoHashCodeAvailableException(typeof(OrderedStack));

    public static bool operator ==(OrderedStack? left, OrderedStack? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(OrderedStack? left, OrderedStack? right)
    {
        return !Equals(left, right);
    }
}