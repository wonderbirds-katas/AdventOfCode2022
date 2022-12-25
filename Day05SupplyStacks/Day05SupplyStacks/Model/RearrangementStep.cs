namespace Day05SupplyStacks.Model;

public record RearrangementStep(int NumberOfCrates, int FromStackIndex, int ToStackIndex)
{
    public override string ToString() =>
        $"move {NumberOfCrates} from {FromStackIndex + 1} to {ToStackIndex + 1}";
}
