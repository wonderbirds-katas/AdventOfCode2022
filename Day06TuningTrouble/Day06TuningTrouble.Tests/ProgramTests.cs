namespace Day06TuningTrouble.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData(4, "./data/advent_of_code_example_1.txt", 7)]
    [InlineData(4, "./data/advent_of_code_example_2.txt", 5)]
    [InlineData(4, "./data/advent_of_code_example_3.txt", 6)]
    [InlineData(4, "./data/advent_of_code_example_4.txt", 10)]
    [InlineData(4, "./data/advent_of_code_example_5.txt", 11)]
    [InlineData(4, "./data/advent_of_code_stefans_personal_data.txt", 1175)]
    [InlineData(14, "./data/advent_of_code_example_1.txt", 19)]
    [InlineData(14, "./data/advent_of_code_example_2.txt", 23)]
    [InlineData(14, "./data/advent_of_code_example_3.txt", 23)]
    [InlineData(14, "./data/advent_of_code_example_4.txt", 29)]
    [InlineData(14, "./data/advent_of_code_example_5.txt", 26)]
    [InlineData(14, "./data/advent_of_code_stefans_personal_data.txt", 3217)]
    public void ProcessInputFile(int length, string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { length.ToString(), testFileName });

        stringWriter.ToString().Should().Be($"{expected}\n");
    }
}
