using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Services;

public static class CargoCraneOperator
{
    public static void Execute(RearrangementProcedure procedure, OrderedStock stock) =>
        procedure.Steps
            .ToList()
            .ForEach(
                step => stock.Move(step.NumberOfCrates, step.FromStackIndex, step.ToStackIndex)
            );
}
