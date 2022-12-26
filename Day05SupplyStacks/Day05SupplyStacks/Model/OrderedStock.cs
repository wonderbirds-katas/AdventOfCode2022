namespace Day05SupplyStacks.Model;

public class OrderedStock
{
    private readonly List<CrateStack> _stacks;

    public string TopCrates => new(_stacks.Select(x => x.Top).ToArray());

    public OrderedStock(List<CrateStack> stacks) => _stacks = stacks;

    public void Move(int numberOfCrates, int fromStackIndex, int toStackIndex) =>
        _stacks[fromStackIndex]
            .TakeFromTop(numberOfCrates)
            .ToList()
            .ForEach(crate => _stacks[toStackIndex].AddOnTop(crate));

    public override string ToString() => $"[{string.Join(", ", _stacks)}]";

    protected bool Equals(OrderedStock other) => _stacks.SequenceEqual(other._stacks);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((OrderedStock)obj);
    }

    public override int GetHashCode() =>
        throw new NoHashCodeAvailableException(typeof(OrderedStock));

    public static bool operator ==(OrderedStock? left, OrderedStock? right) => Equals(left, right);

    public static bool operator !=(OrderedStock? left, OrderedStock? right) => !Equals(left, right);
}
