using Day05SupplyStacks.Adapters;

namespace Day05SupplyStacks.Tests.Adapters;

public class RearrangementProcedureDeserializerTests
{
    [Fact]
    public void Deserialize()
    {
        var actual = RearrangementProcedureDeserializer.Deserialize(new[] { "move 1 from 1 to 1" });
    }
}