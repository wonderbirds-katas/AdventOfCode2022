namespace Day05SupplyStacks;

public class NoHashCodeAvailableException : NotSupportedException
{
    public NoHashCodeAvailableException(Type type)
        : base(
            $"The current implementation of '{type.Name}' does not allow hashing, because '{type.Name}' contains mutable state."
        ) { }
}
