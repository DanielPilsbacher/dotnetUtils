using System.Diagnostics;
using System.Text;
using DotNetUtils.StringUtils;
using NLog;
using Tests.DotnetUtils;

namespace DotNetUtils.Tests.StringUtils;

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
        for (int durationCounts = 1; !passed && durationCounts <= 2500; durationCounts++)
        {
            float stringConcatinationDuration = GetStringConcatinationDuration(durationCounts);
            float stringTextConcatinationDuration = GetStringTextConcatinationDuration(durationCounts);
            performancePercent = 100 * (uint)stringConcatinationDuration / (uint)stringTextConcatinationDuration;
            passed = performancePercent >= 100;
            Log.Debug("--  StringTextTest.PerformanceTest -----------------------------------------");
            Log.Debug(nameof(String) + " duration is     '" + stringConcatinationDuration + "' ns.");
            Log.Debug(nameof(StringText) + " duration is '" + stringTextConcatinationDuration + "' ns.");
            Log.Debug("The performance is " + performancePercent + "% with '" + (durationCounts) + "' concatinations.");
            Log.Debug("Teststatus [" + (passed ? "PASSED" : "FAILED") + "]");
            Log.Debug("The duration for " + nameof(StringText) + " shall be less than for " + nameof(String) + ".");
            Log.Debug("----------------------------------------------------------------------------");
        }
        Assert.That(passed);
    }

    [Test]
    public void BenchmarkTest()
    {
        Log.Debug("Iterations\tstring\tStringBuilder\tStringText\tstring\tStringBuilder\tStringText");
        Log.Debug("Count\tTicks\tTicks\tTicks\tIterations/Tick\tIterations/Tick\tIterations/Tick");
        for (float counts = 1; counts <= 2500; counts++)
        {
            float stringConcatinationDuration = GetStringConcatinationDuration((int)counts);
            float stringBuilderConcatinationDuration = GetStringBuilderDuration((int)counts);
            float stringTextConcatinationDuration = GetStringTextConcatinationDuration((int)counts);
            Log.Debug($"\t{counts}" +
                $"\t{stringConcatinationDuration}\t{stringBuilderConcatinationDuration}\t{stringTextConcatinationDuration}" +
                $"\t{((counts/stringConcatinationDuration)).ToString("0.00")}" +
                $"\t{((counts /stringBuilderConcatinationDuration)).ToString("0.00")}" +
                $"\t{((counts /stringTextConcatinationDuration)).ToString("0.00")}");
        }
    }

    private static float GetStringConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        string s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return (float)stopwatch4String.Elapsed.Ticks;
    }

    private static float GetStringBuilderDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        StringBuilder s = new StringBuilder();
        for (int i = 0; i <= durationStop; i++)
        {
            s.Append(i == 0 ? "" : ", ").Append(i);
        }
        stopwatch4String.Stop();
        return (float)stopwatch4String.Elapsed.Ticks;
    }

    private static float GetStringTextConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        StringText s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return (float)stopwatch4String.Elapsed.Ticks;
    }
}
