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
            new(
                "2 stacks, 0 crates",
                new[] { " 1   2 " },
                OrderedStockBuilder.WithNumberOfStacks(2).Build()
            ),
            new(
                "2 stacks, 1 crate on each",
                new[] { "[A] [B]", " 1   2 " },
                OrderedStockBuilder
                    .WithNumberOfStacks(2)
                    .AddCratesToStack(new[] { 'A' }, 0)
                    .AddCratesToStack(new[] { 'B' }, 1)
                    .Build()
            ),
            new(
                "9 stacks, 0 crates",
                new[] { " 1   2   3   4   5   6   7   8   9 " },
                OrderedStockBuilder.WithNumberOfStacks(9).Build()
            ),
            new(
                "9 stacks, some crates on each",
                new[]
                {
                    "                        [G]        ",
                    "    [B]         [E]     [G]        ",
                    "    [B] [C]     [E] [F] [G]        ",
                    "[A] [B] [C] [D] [E] [F] [G] [H] [I]",
                    " 1   2   3   4   5   6   7   8   9 "
                },
                OrderedStockBuilder
                    .WithNumberOfStacks(9)
                    .AddCratesToStack(new[] { 'A' }, 0)
                    .AddCratesToStack(new[] { 'B', 'B', 'B' }, 1)
                    .AddCratesToStack(new[] { 'C', 'C' }, 2)
                    .AddCratesToStack(new[] { 'D' }, 3)
                    .AddCratesToStack(new[] { 'E', 'E', 'E' }, 4)
                    .AddCratesToStack(new[] { 'F', 'F' }, 5)
                    .AddCratesToStack(new[] { 'G', 'G', 'G', 'G' }, 6)
                    .AddCratesToStack(new[] { 'H' }, 7)
                    .AddCratesToStack(new[] { 'I' }, 8)
                    .Build()
            ),
        };

        public static IEnumerable<object[]> TestCaseData =>
            TestCases.Select(testCase => new object[] { testCase });

        public override string ToString() => Description;
    }
}
