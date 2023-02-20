namespace Day08TreetopTreeHouse.Tests;

public class ProgramTests
{
    private readonly StringWriter _stringWriter;

    public ProgramTests()
    {
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }
    
    [Theory]
    [InlineData("./data/advent_of_code_example.txt", 21)]
    [InlineData("./data/regression_trees_not_visible_from_right_or_bottom.txt", 25 - 9 + 8)]
    [InlineData("./data/advent_of_code_stefans_personal_data.txt", 1733)]
    public void Part1Tests(string testFileName, int expected)
    {
        Program.Main(1, new FileInfo(testFileName));
        _stringWriter.ToString().Should().Be($"{expected}\n");
    }
    
    [Theory]
    [InlineData("./data/single_tree.txt", 0)]
    public void Part2Tests(string testFileName, int expected)
    {
        Program.Main(2, new FileInfo(testFileName));
        _stringWriter.ToString().Should().Be($"{expected}\n");
    }
}
