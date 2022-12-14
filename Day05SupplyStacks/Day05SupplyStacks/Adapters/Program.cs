using Day05SupplyStacks.Model;
using Day05SupplyStacks.Services;

namespace Day05SupplyStacks.Adapters;

public static class Program
{
    public static void Main(string[] args)
    {
        var linesInFile = File.ReadAllLines(args[0]);
        var stock = DeserializeStock(linesInFile);
        var procedure = DeserializeRearrangementProcedure(linesInFile);

        CargoCraneOperator.Execute(procedure, stock);

        Console.WriteLine(stock.TopCrates);
    }

    private static OrderedStock DeserializeStock(IEnumerable<string> linesInFile)
    {
        var stockSpecification = linesInFile.TakeWhile(line => line != "");
        return StockSpecificationDeserializer.Deserialize(stockSpecification);
    }

    private static RearrangementProcedure DeserializeRearrangementProcedure(
        IEnumerable<string> linesInFile
    )
    {
        var procedureSpecification = linesInFile.SkipWhile(line => line != "").Skip(1);
        return RearrangementProcedureDeserializer.Deserialize(procedureSpecification);
    }
}
