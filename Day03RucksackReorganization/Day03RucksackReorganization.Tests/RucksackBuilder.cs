namespace Day03RucksackReorganization.Tests;

public static class RucksackBuilder
{
    public static Rucksack PackRucksackWith(char[] itemsInFirstCompartment, char[] itemsInSecondCompartment)
    {
        var result = new Rucksack();

        AddItemsToCompartment(itemsInFirstCompartment, result.FirstCompartment);
        AddItemsToCompartment(itemsInSecondCompartment, result.SecondCompartment);

        return result;
    }

    private static void AddItemsToCompartment(char[] itemsInFirstCompartment, Compartment compartment)
    {
        if (itemsInFirstCompartment.Length == 0) return;
        
        Array.ForEach(itemsInFirstCompartment,
            itemType => compartment.Add(new Item(itemType)));

        var expected = itemsInFirstCompartment.Select(itemType => new Item(itemType));
        compartment.Items.Should().Contain(expected);
    }
}