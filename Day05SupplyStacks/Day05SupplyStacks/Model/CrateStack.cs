namespace Day05SupplyStacks.Model;

public class CrateStack
{
    protected bool Equals(CrateStack other)
    {
        return true;
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
        return 0;
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