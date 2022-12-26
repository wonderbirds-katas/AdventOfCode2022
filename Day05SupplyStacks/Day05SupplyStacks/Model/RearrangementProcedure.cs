namespace Day05SupplyStacks.Model;

public class RearrangementProcedure
{
    private readonly List<RearrangementStep> _steps = new();

    public IEnumerable<RearrangementStep> Steps => _steps;

    public void Add(RearrangementStep step) => _steps.Add(step);

    protected bool Equals(RearrangementProcedure other) => _steps.SequenceEqual(other._steps);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        return Equals((RearrangementProcedure)obj);
    }

    public override int GetHashCode() =>
        throw new NoHashCodeAvailableException(typeof(RearrangementProcedure));

    public static bool operator ==(RearrangementProcedure? left, RearrangementProcedure? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(RearrangementProcedure? left, RearrangementProcedure? right)
    {
        return !Equals(left, right);
    }

    public override string ToString() => $"[{string.Join(", ", Steps)}]";
}
