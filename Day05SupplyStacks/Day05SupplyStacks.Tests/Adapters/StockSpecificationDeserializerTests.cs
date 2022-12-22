using System.Collections;
using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Adapters;

public class StockSpecificationDeserializerTests
{
    private static readonly string[] SingleEmptyStack = { "1" };

    [Theory]
    [ClassData(typeof(StockSpecificationDeserializerTestData))]
    public void NextTestWithoutMeaningfulName(string[] input, OrderedStack expected)
    {
        var actual = new OrderedStack();
        actual.Should().BeOfType(typeof(OrderedStack));
    }

    private class StockSpecificationDeserializerTestData : IEnumerable<object []>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {SingleEmptyStack, new OrderedStack()};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}