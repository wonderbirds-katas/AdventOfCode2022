namespace Day04CampCleanup.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/single_pair_no_overlap.txt", 0)]
    [InlineData("./data/advent_of_code_example.txt", 2)]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", 599)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        Assert.Equal($"{expected}\n", stringWriter.ToString());
    }
}
