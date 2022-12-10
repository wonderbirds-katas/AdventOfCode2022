namespace Day02RockPaperScissors.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("ProgramTestInput.txt", 45)]
    public void ProcessInputFile(string testFileName, int expectedSum)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        Program.Main(new[] {testFileName});
        
        Assert.Equal($"{expectedSum}\n", stringWriter.ToString());
    }
}
