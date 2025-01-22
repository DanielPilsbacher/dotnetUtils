using NLog;
using NLog.Config;
using NLog.Targets;

namespace Tests.DotnetUtils;

public abstract class TestBase
{
    public Logger Log { get; set; }

    public TestBase(Logger log)
    {
        LoggingConfiguration config;
        ConsoleTarget logconsole;
        config = new LoggingConfiguration();
        logconsole = new ConsoleTarget("logconsole");
        config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
        LogManager.Configuration = config;
        Log = log;
    }
}
