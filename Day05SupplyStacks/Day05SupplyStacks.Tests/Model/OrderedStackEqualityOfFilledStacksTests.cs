using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Tests.Model;

public class OrderedStackEqualityOfFilledStacksTests
{
    [Fact]
    public void SameStacks()
    {
        var left = OrderedStockBuilder
            .WithNumberOfStacks(1)
            .AddCratesToStack(new[] { 'A' }, 0)
            .Build();

        var right = OrderedStockBuilder
            .WithNumberOfStacks(1)
            .AddCratesToStack(new[] { 'A' }, 0)
            .Build();

        left.Equals(right).Should().Be(true);
    }

    [Theory]
    [InlineData(new[] { 'A' }, new[] { 'B' })]
    [InlineData(new[] { 'A', 'B', 'C' }, new[] { 'B' })]
    [InlineData(new[] { 'A', 'B', 'C' }, new[] { 'C', 'B', 'A' })]
    public void DifferentStacks(char[] leftCrates, char[] rightCrates)
    {
        var left = OrderedStockBuilder
            .WithNumberOfStacks(1)
            .AddCratesToStack(leftCrates, 0)
            .Build();

        var right = OrderedStockBuilder
            .WithNumberOfStacks(1)
            .AddCratesToStack(rightCrates, 0)
            .Build();

        left.Should().NotBe(right);
    }

    [Fact]
    public void MultipleStacksWithEqualCrates()
    {
        var left = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B' }, 0)
            .AddCratesToStack(new[] { 'C', 'D', 'E' }, 1)
            .AddCratesToStack(new[] { 'F', 'G', 'H', 'I' }, 2)
            .Build();

        var right = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B' }, 0)
            .AddCratesToStack(new[] { 'C', 'D', 'E' }, 1)
            .AddCratesToStack(new[] { 'F', 'G', 'H', 'I' }, 2)
            .Build();

        left.Should().Be(right);
    }

    [Fact]
    public void MultipleStacksWithDifferentCrates()
    {
        const char Difference = 'Z';

        var left = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B' }, 0)
            .AddCratesToStack(new[] { 'C', 'D', 'E' }, 1)
            .AddCratesToStack(new[] { 'F', 'G', 'H', 'I' }, 2)
            .Build();

        var right = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B' }, 0)
            .AddCratesToStack(new[] { 'C', 'D', Difference }, 1)
            .AddCratesToStack(new[] { 'F', 'G', 'H', 'I' }, 2)
            .Build();

        left.Should().NotBe(right);
    }
}
