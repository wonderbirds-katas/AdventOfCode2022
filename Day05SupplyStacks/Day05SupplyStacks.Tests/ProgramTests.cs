namespace Day05SupplyStacks.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/advent_of_code_example.txt", "MCD\n")]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", "RBTWJWMCF\n")]
    public void ProcessInputFile(string testFileName, string expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        Assert.Equal(expected, stringWriter.ToString());
    }
}
