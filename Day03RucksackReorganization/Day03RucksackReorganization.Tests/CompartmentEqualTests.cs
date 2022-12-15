namespace Day03RucksackReorganization.Tests;

public class CompartmentTests
{
    [Fact]
    public void EmptyCompartmentsAreEqual()
    {
        var first = new Compartment();
        var second = new Compartment();
        
        Assert.Equal(first, second);
    }
}