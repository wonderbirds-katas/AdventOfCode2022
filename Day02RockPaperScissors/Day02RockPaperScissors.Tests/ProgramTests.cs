namespace Day02RockPaperScissors.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/AllCombinations.txt", 45)]
    [InlineData("./data/StefansPersonalDataFromAdventOfCode.txt", 14069)]
    [InlineData("./data/TugbaysPersonalDataFromAdventOfCode.txt", 11475)]
    public void ProcessInputFile(string testFileName, int expectedSum)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        Program.Main(new[] {testFileName});
        
        Assert.Equal($"{expectedSum}\n", stringWriter.ToString());
    }
}
