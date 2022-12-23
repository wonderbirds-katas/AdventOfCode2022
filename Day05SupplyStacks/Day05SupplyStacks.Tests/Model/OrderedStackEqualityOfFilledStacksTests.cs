namespace Day05SupplyStacks.Tests.Model;

public class OrderedStackEqualityOfFilledStacksTests
{
    [Fact]
    public void SameStacks()
    {
        var left = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(new []{ 'A' }, 0)
            .Build();

        var right = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(new []{ 'A' }, 0)
            .Build();

        left.Equals(right).Should().Be(true);
    }

    [Fact]
    public void DifferentStacks()
    {
        var left = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(new []{ 'A' }, 0)
            .Build();

        var right = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(new []{ 'B' }, 0)
            .Build();

        left.Should().NotBe(right);
    }
}
