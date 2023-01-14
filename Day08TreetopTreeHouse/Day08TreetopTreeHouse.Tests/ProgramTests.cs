namespace Day08TreetopTreeHouse.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/advent_of_code_example.txt", 21)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        stringWriter.ToString().Should().Be($"{expected}\n");
    }
}
