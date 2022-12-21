namespace Day05SupplyStacks.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/SampleData.txt")]
    public void ProcessInputFile(string testFileName)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        Assert.Equal($"Input file is '{testFileName}'\n", stringWriter.ToString());
    }
}
