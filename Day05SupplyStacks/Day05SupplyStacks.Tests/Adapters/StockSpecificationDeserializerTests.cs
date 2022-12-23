using System.Collections;
using Day05SupplyStacks.Adapters;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class StockSpecificationDeserializerTests
{
    [Theory]
    [ClassData(typeof(StockSpecificationDeserializerTestData))]
    public void Deserialize(string[] input, OrderedStock expected)
    {
        var actual = StockSpecificationDeserializer.Deserialize(input);
        actual.Should().BeEquivalentTo(expected);
    }

    private class StockSpecificationDeserializerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new[] { "1" },
                OrderedStockBuilder.WithNumberOfStacks(1).Build()
            };

            yield return new object[]
            {
                new[] {
                    "[A]",
                    " 1 "
                },
                OrderedStockBuilder.WithNumberOfStacks(1)
                    .AddCratesToStack(new []{ 'A' }, 0)
                    .Build()
            };

            yield return new object[]
            {
                new[] {
                    "[C]",
                    "[B]",
                    "[A]",
                    " 1 "
                },
                OrderedStockBuilder.WithNumberOfStacks(1)
                    .AddCratesToStack(new []{ 'A', 'B', 'C' }, 0)
                    .Build()
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}