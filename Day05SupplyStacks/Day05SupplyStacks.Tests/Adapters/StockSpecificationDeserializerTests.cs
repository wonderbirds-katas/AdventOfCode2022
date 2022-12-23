using Day05SupplyStacks.Adapters;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class StockSpecificationDeserializerTests
{
    [Theory]
    [MemberData(nameof(TestCase.TestCaseData), MemberType = typeof(TestCase))]
    public void Deserialize2(TestCase testCase)
    {
        var actual = StockSpecificationDeserializer.Deserialize(testCase.Input);
        actual.Should().BeEquivalentTo(testCase.Expected);
    }

    public record TestCase(string Description, string[] Input, OrderedStock Expected)
    {
        private static readonly TestCase[] TestCases =
        {
            new(
                "1 stack, 0 crates",
                new[] { " 1 " },
                OrderedStockBuilder.WithNumberOfStacks(1).Build()
            ),
            new(
                "1 stack, 1 crate",
                new[] { "[A]", " 1 " },
                OrderedStockBuilder.WithNumberOfStacks(1).AddCratesToStack(new[] { 'A' }, 0).Build()
            ),
            new(
                "1 stack, 3 crates",
                new[] { "[C]", "[B]", "[A]", " 1 " },
                OrderedStockBuilder
                    .WithNumberOfStacks(1)
                    .AddCratesToStack(new[] { 'A', 'B', 'C' }, 0)
                    .Build()
            ),
        };

        public static IEnumerable<object[]> TestCaseData =>
            TestCases.Select(testCase => new object[] { testCase });

        public override string ToString() => Description;
    }
}
