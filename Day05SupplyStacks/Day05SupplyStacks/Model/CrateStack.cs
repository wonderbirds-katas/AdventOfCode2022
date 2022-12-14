namespace Day05SupplyStacks.Model;

public class CrateStack
{
    private readonly Stack<char> _crates = new();

    public char Top => _crates.Peek();

    public void AddOnTop(char crate)
    {
        _crates.Push(crate);
    }

    public IEnumerable<char> TakeFromTop(int numberOfCrates) =>
        Enumerable.Range(0, numberOfCrates).Select(_ => _crates.Pop()).Reverse();

    protected bool Equals(CrateStack other) => _crates.SequenceEqual(other._crates);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((CrateStack)obj);
    }

    public override string ToString() => $"[Top: {string.Join(", ", _crates)}]";

    public override int GetHashCode() => throw new NoHashCodeAvailableException(typeof(CrateStack));

    public static bool operator ==(CrateStack? left, CrateStack? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(CrateStack? left, CrateStack? right)
    {
        return !Equals(left, right);
    }
}
