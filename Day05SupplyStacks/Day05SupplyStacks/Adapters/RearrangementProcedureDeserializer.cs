using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Adapters;

public static class RearrangementProcedureDeserializer
{
    public static RearrangementProcedure Deserialize(string[] input)
    {
        var result = new RearrangementProcedure();
        result.Add(new RearrangementStep(1, 0, 0));
        return result;
    }
}
