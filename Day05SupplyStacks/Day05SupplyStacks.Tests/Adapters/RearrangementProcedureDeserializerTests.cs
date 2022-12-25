using Day05SupplyStacks.Adapters;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class RearrangementProcedureDeserializerTests
{
    [Fact]
    public void Deserialize()
    {
        var actual = RearrangementProcedureDeserializer.Deserialize(new[] { "move 1 from 1 to 1" });

        var expected = new RearrangementProcedure();
        expected.Add(new RearrangementStep(1, 0, 0));
        actual.Should().Be(expected);
    }
}
