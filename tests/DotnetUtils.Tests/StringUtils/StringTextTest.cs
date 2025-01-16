using System.Diagnostics;
using DotNetUtils.StringUtils;
using NLog;
using Tests.DotnetUtils.Collections;

namespace DotNetUtils.Test.StringUtils;

#pragma warning disable

public class StringTextTest : TestBase
{
    public StringTextTest() : base(LogManager.GetCurrentClassLogger())
    {
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
        Log.Debug("Run unittest " + nameof(StringTextTest) + "." + nameof(PerformanceTest));
        bool passed = false;
        uint performancePercent = 0;
        for (int durationCounts = (int)Math.Exp(1); (durationCounts <= 25000) && !passed; durationCounts = (int)(Math.Exp(durationCounts)))
        {
            long stringConcatinationDuration = GetStringConcatinationDuration(durationCounts);
            long stringTextConcatinationDuration = GetStringTextConcatinationDuration(durationCounts);
            performancePercent = 100 * (uint)stringConcatinationDuration / (uint)stringTextConcatinationDuration;
            passed = performancePercent >= 100;
            Log.Debug("--  StringTextTest.PerformanceTest -----------------------------------------");
            Log.Debug(nameof(String) + " duration is     '" + stringConcatinationDuration + "' ns.");
            Log.Debug(nameof(StringText) + " duration is '" + stringTextConcatinationDuration +  "' ns.");
            Log.Debug("The performance is " + performancePercent + "% with '" + durationCounts + "' concatinations.");
            Log.Debug("Teststatus [" + (passed ? "PASSED" : "FAILED") + "]");
            Log.Debug("The duration for " + nameof(StringText) + " shall be less than for " + nameof(String) + ".");
            Log.Debug("----------------------------------------------------------------------------");
        }
        Assert.That(passed);
    }

    private static int GetStringConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        string s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.Elapsed.Nanoseconds;
    }

    private static int GetStringTextConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        StringText s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.Elapsed.Nanoseconds;
    }
}
