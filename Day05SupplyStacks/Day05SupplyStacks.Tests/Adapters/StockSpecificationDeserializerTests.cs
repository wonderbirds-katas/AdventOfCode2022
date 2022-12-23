using System.Collections;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class StockSpecificationDeserializerTests
{
    private static readonly string[] SingleEmptyStackSerialized = { "1" };

    [Theory]
    [ClassData(typeof(StockSpecificationDeserializerTestData))]
    public void NextTestWithoutMeaningfulName(string[] input, OrderedStack expected)
    {
        var actual = new OrderedStack(new List<CrateStack> { new() });
        actual.Should().BeEquivalentTo(expected);
    }

    private class StockSpecificationDeserializerTestData : IEnumerable<object []>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {SingleEmptyStackSerialized, new OrderedStack(new List<CrateStack> { new() })};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}