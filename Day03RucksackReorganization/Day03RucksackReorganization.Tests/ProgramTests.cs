namespace Day03RucksackReorganization.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/single_group_with_shared_a.txt", 1)]
    [InlineData("./data/advent_of_code_example.txt", 70)]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", 2631)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        Assert.Equal($"{expected}\n", stringWriter.ToString());
    }
}
