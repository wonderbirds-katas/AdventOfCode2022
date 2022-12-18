namespace Day03RucksackReorganization.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/single_rucksack_with_duplicate_a.txt", 1)]
    [InlineData("./data/two_rucksacks_with_duplicates_a_a.txt", 2)]
    [InlineData("./data/two_rucksacks_with_duplicates_b_b.txt", 4)]
    public void ProcessInputFile(string testFileName, int expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        Program.Main(new[] {testFileName});
        
        Assert.Equal($"{expected}\n", stringWriter.ToString());
    }
}
