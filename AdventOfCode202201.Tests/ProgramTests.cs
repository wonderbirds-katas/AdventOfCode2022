using MELT;
using Microsoft.Extensions.Logging;

namespace AdventOfCode202201.Tests;

public class ProgramTests
{
    [Fact]
    public void ProgramProcessesInputFile()
    {
        var loggerFactory = TestLoggerFactory.Create();
        var logger = loggerFactory.CreateLogger<Program>();

        var program = new Program(logger);
        program.Run(new[] { "SingleElf_SingleFoodItem.txt" });

        var log = Assert.Single(loggerFactory.Sink.LogEntries);
        Assert.Equal("SingleElf_SingleFoodItem.txt", log.Message);
    }
}
