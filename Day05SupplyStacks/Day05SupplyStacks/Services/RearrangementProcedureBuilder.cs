using Day05SupplyStacks.Model;

namespace Day05SupplyStacks.Services;

public class RearrangementProcedureBuilder
{
    private readonly RearrangementProcedure _procedure = new();

    public RearrangementProcedure Build() => _procedure;

    public RearrangementProcedureBuilder AddMoveStep(int numberOfCrates, int from, int to)
    {
        _procedure.Add(new RearrangementStep(numberOfCrates, from - 1, to - 1));
        return this;
    }
}
