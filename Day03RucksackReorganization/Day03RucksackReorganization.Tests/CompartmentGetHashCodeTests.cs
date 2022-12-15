namespace Day03RucksackReorganization.Tests;

public class CompartmentGetHashCodeTests
{
    [Fact(Skip = "TODO: Implement GetHashCode correctly")]
    public void EmptyCompartments()
    {
        Compartment first = new ();
        Compartment second = new ();
        
        Assert.Equal(first.GetHashCode(), second.GetHashCode());
    }
}