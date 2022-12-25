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
            ),
            new(
                "move 999 from 100 to 50",
                new[] { "move 999 from 100 to 50" },
                new RearrangementProcedureBuilder().AddMoveStep(999, 100, 50).Build()
            ),
            new(
                "2 move steps",
                new[] { "move 3 from 1 to 5", "move 2 from 5 to 3" },
                new RearrangementProcedureBuilder()
                    .AddMoveStep(3, 1, 5)
                    .AddMoveStep(2, 5, 3)
                    .Build()
            ),
        };

        public static IEnumerable<object[]> TestCaseData =>
            TestCases.Select(testCase => new object[] { testCase });

        public override string ToString() => Description;
    }
}
