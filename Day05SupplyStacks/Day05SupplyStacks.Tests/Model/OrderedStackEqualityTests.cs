using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class OrderedStackEqualityTests
{
    [Fact]
    public void Empty() => RunTest(true, 0, 0);

    [Theory]
    [InlineData(1, 0, false)]
    public void LeftContainsMoreStacksThanRight(int leftStockNumberOfStacks, int rightStockNumberOfStacks, bool expected) => RunTest(expected, leftStockNumberOfStacks, rightStockNumberOfStacks);
    
    [Theory]
    [InlineData(2, 2, true)]
    public void SameNumberOfEmptyStacks(int leftStockNumberOfStacks, int rightStockNumberOfStacks, bool expected) => RunTest(expected, leftStockNumberOfStacks, rightStockNumberOfStacks);

    [Theory]
    [InlineData(1, 2, false)]
    public void LeftContainsFewerStacksThanRight(int leftStockNumberOfStacks, int rightStockNumberOfStacks, bool expected) => RunTest(expected, leftStockNumberOfStacks, rightStockNumberOfStacks);

    private static void RunTest(bool expected, int leftStockNumberOfStacks, int rightStockNumberOfStacks)
    {
        var left = CreateOrderedStockWithNumberOfEmptyStacks(leftStockNumberOfStacks);
        var right = CreateOrderedStockWithNumberOfEmptyStacks(rightStockNumberOfStacks);

        (left == right).Should().Be(expected);
    }

    private static OrderedStock CreateOrderedStockWithNumberOfEmptyStacks(int numberOfStacks) =>
        new(Enumerable.Range(0, numberOfStacks)
            .Select(_ => new CrateStack())
            .ToList());
}
