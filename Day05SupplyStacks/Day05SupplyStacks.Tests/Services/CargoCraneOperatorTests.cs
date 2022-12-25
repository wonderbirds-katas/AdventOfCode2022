using Day05SupplyStacks.Model;
using Day05SupplyStacks.Services;

namespace Day05SupplyStacks.Tests.Services;

public class CargoCraneOperatorTests
{
    [Fact]
    public void MoveSingleCrate()
    {
        var stock = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B', 'C', 'D' }, 0)
            .AddCratesToStack(new[] { 'L' }, 1)
            .AddCratesToStack(new[] { 'X', 'Y', 'Z' }, 2)
            .Build();

        var procedure = new RearrangementProcedureBuilder().AddMoveStep(1, 1, 2).Build();

        CargoCraneOperator.Execute(procedure, stock);

        var expected = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B', 'C' }, 0)
            .AddCratesToStack(new[] { 'L', 'D' }, 1)
            .AddCratesToStack(new[] { 'X', 'Y', 'Z' }, 2)
            .Build();

        stock.Should().Be(expected);
    }

    [Fact]
    public void MoveMultipleCrates()
    {
        var stock = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'B', 'C', 'D' }, 0)
            .AddCratesToStack(new[] { 'L' }, 1)
            .AddCratesToStack(new[] { 'X', 'Y', 'Z' }, 2)
            .Build();

        var procedure = new RearrangementProcedureBuilder()
            .AddMoveStep(3, 1, 2)
            .AddMoveStep(2, 2, 3)
            .AddMoveStep(1, 3, 1)
            .Build();

        CargoCraneOperator.Execute(procedure, stock);

        var expected = OrderedStockBuilder
            .WithNumberOfStacks(3)
            .AddCratesToStack(new[] { 'A', 'D' }, 0)
            .AddCratesToStack(new[] { 'L', 'B' }, 1)
            .AddCratesToStack(new[] { 'X', 'Y', 'Z', 'C' }, 2)
            .Build();

        stock.Should().Be(expected);
    }
}
