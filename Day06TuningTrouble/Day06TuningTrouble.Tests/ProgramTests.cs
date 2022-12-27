namespace Day06TuningTrouble.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/advent_of_code_example_1.txt", 5)]
    [InlineData("./data/advent_of_code_example_2.txt", 6)]
    [InlineData("./data/advent_of_code_example_3.txt", 10)]
    [InlineData("./data/advent_of_code_example_4.txt", 11)]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", 1175)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        stringWriter.ToString().Should().Be($"{expected}\n");
    }
}
