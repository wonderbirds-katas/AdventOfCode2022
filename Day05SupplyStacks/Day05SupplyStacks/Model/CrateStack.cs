namespace Day05SupplyStacks.Model;

public class CrateStack
{
    public char Top { get; internal set; }

    public void AddOnTop(char crate)
    {
        Top = crate;
    }

    protected bool Equals(CrateStack other)
    {
        return Top == other.Top;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CrateStack) obj);
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException("The current implementation of CrateStack does not allow hashing, because the CreateStack contains mutable state.");
    }

    public static bool operator ==(CrateStack? left, CrateStack? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(CrateStack? left, CrateStack? right)
    {
        return !Equals(left, right);
    }
}