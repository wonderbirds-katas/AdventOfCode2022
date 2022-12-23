namespace Day05SupplyStacks.Model;

public class CrateStack
{
    private readonly Stack<char> _crates = new();

    public void AddOnTop(char crate)
    {
        _crates.Push(crate);
    }

    protected bool Equals(CrateStack other) => _crates.SequenceEqual(other._crates);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CrateStack) obj);
    }

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