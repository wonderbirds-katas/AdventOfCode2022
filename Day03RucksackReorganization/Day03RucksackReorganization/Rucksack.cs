namespace Day03RucksackReorganization;

public record struct Rucksack(Compartment FirstCompartment, Compartment SecondCompartment)
{
    public Rucksack() : this(new Compartment(), new Compartment())
    {
    }
}
