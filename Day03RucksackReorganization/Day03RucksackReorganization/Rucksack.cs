namespace Day03RucksackReorganization;

public class Rucksack
{
    public Compartment FirstCompartment { get; } = new();
    public Compartment SecondCompartment { get; } = new();
    public override string ToString() => $"{{{FirstCompartment}, {SecondCompartment}}}";
}