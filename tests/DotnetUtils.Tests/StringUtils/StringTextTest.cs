using System.Diagnostics;
using DotNetUtils.StringUtils;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace DotNetUtils.Test.StringUtils;

public class StringTextTest
{
    private readonly Logger _log;

    public StringTextTest()
    {
        LoggingConfiguration config;
        ConsoleTarget logconsole;
        config = new LoggingConfiguration();
        logconsole = new ConsoleTarget("logconsole");                    
        config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
        LogManager.Configuration = config;
        _log = LogManager.GetCurrentClassLogger();
    }

    [Test]
    public void Test()
    {
        StringText text = "Hello";
        Assert.That(text.ToString(), Is.EqualTo("Hello"));
        StringText text2 = " ";
        StringText text3 = "StringText!";
        Assert.That((text + text2 + text3).ToString(), Is.EqualTo("Hello StringText!"));
    }

    [Test]
    public void PerformanceTest()
    {
        _log.Debug("Run unittest " + nameof(StringTextTest) + "." + nameof(PerformanceTest));
        bool passed = false;
        uint performancePercent = 0;
        for (int durationCounts = (int)Math.Exp(1); (durationCounts <= 25000) && !passed; durationCounts = (int)(Math.Exp(durationCounts)))
        {
            long stringConcatinationDurationTicks = GetStringConcatinationDurationTicks(durationCounts);
            long stringTextConcatinationDurationTicks = GetStringTextConcatinationDurationTicks(durationCounts);
            performancePercent = 100 * (uint)stringConcatinationDurationTicks / (uint)stringTextConcatinationDurationTicks;
            passed = performancePercent >= 100;
            _log.Debug("--  StringTextTest.PerformanceTest -----------------------------------------");
            _log.Debug(nameof(String) + " duration is     '" + stringConcatinationDurationTicks + "' ticks.");
            _log.Debug(nameof(StringText) + " duration is '" + stringTextConcatinationDurationTicks +  "' ticks.");
            _log.Debug("The performance is " + performancePercent + "% with '" + durationCounts + "' concatinations.");
            _log.Debug("Teststatus [" + (passed ? "PASSED" : "FAILED") + "]");
            _log.Debug("The duration for " + nameof(StringText) + " shall be less than for " + nameof(String) + ".");
            _log.Debug("----------------------------------------------------------------------------");
        }
        Assert.That(passed);
    }

    private long GetStringConcatinationDurationTicks(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        string s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.ElapsedTicks;
    }

    private long GetStringTextConcatinationDurationTicks(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        StringText s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.ElapsedTicks;
    }
}
