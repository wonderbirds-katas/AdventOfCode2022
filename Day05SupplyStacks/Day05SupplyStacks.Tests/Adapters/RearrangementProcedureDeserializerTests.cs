using Day05SupplyStacks.Adapters;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class RearrangementProcedureDeserializerTests
{
    [Theory]
    [MemberData(nameof(TestCase.TestCaseData), MemberType = typeof(TestCase))]
    public void Deserialize(TestCase testCase)
    {
        RearrangementProcedureDeserializer
            .Deserialize(testCase.Input)
            .Should()
            .Be(testCase.Expected);
    }

    public record TestCase(string Description, string[] Input, RearrangementProcedure Expected)
    {
        private static readonly TestCase[] TestCases =
        {
            new(
                "move 1 from 1 to 1",
                new[] { "move 1 from 1 to 1" },
                new RearrangementProcedureBuilder().AddMoveStep(1, 1, 1).Build()
            )
        };

        public static IEnumerable<object[]> TestCaseData =>
            TestCases.Select(testCase => new object[] { testCase });

        public override string ToString() => Description;
    }
}
