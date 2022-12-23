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

    [Theory]
    [InlineData(new[] {'A'}, new[] {'B'})]
    [InlineData(new[] {'A','B','C'}, new[] {'B'})]
    [InlineData(new[] {'A','B','C'}, new[] {'C','B','A'})]
    public void DifferentStacks(char[] leftCrates, char[] rightCrates)
    {
        var left = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(leftCrates, 0)
            .Build();

        var right = OrderedStockBuilder.WithNumberOfStacks(1)
            .AddCratesToStack(rightCrates, 0)
            .Build();

        left.Should().NotBe(right);
    }
}
