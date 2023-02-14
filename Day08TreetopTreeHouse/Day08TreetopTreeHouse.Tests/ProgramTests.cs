namespace Day08TreetopTreeHouse.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/advent_of_code_example.txt", 21)]
    [InlineData("./data/regression_trees_not_visible_from_right_or_bottom.txt", 25 - 9 + 8)]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", 1733)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        stringWriter.ToString().Should().Be($"{expected}\n");
    }
}
