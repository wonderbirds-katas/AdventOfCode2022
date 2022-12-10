namespace Day02RockPaperScissors.Tests;

public class ProgramTests
{
    [Fact]
    public void NextTestWithoutMeaningfulName()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        Program.Main(new[] {"ProgramTestInput.txt"});
        
        Assert.Equal("0\n", stringWriter.ToString());
    }
}