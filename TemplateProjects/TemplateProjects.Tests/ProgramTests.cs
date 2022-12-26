namespace TemplateProjects.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("./data/SampleData.txt")]
    public void ProcessInputFile(string testFileName)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Program.Main(new[] { testFileName });

        stringWriter.ToString().Should().Be($"Input file is '{testFileName}'\n");
    }
}
