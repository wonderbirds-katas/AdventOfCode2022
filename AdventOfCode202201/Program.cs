using Microsoft.Extensions.Logging;

namespace AdventOfCode202201;

public class Program
{
    private static readonly ILoggerFactory LoggerFactory;
    private readonly ILogger _logger;

    static Program()
    {
        LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Information);
            builder.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
            });
        });
    }

    public Program(ILogger logger)
    {
        _logger = logger;
    }

    public static void Main(string[] args)
    {
        new Program(LoggerFactory.CreateLogger<Program>()).Run(args);
    }

    public void Run(string[] args)
    {
        _logger.LogCritical(args[0]);
    }
}
