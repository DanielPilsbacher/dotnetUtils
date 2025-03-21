using System.Diagnostics;
using PilsbacherDaniel.DotnetUtils.StringUtils;
using NLog;
using PilsbacherDaniel.DotnetUtils.Tests;

namespace PilsbacherDaniel.DotNetUtils.Tests.StringUtilsTest;

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
        bool passed = false;
        ushort performancePercent = 0;
        for (int durationCounts = 1 ; durationCounts <= 2500 && !passed; durationCounts++)
        {
            long stringConcatenationDuration = GetStringConcatinationDuration(durationCounts);
            long stringTextConcatenationDuration = GetStringTextConcatinationDuration(durationCounts);
            performancePercent = (ushort)(100 * stringConcatenationDuration / stringTextConcatenationDuration);
            passed = performancePercent >= 100;
        }
        Assert.That(passed);
    }

    private static long GetStringConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        string s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.Elapsed.Ticks;
    }

    private static long GetStringTextConcatinationDuration(int durationStop)
    {
        Stopwatch stopwatch4String = new Stopwatch();
        stopwatch4String.Start();
        StringText s = "";
        for (int i = 0; i <= durationStop; i++)
        {
            s += (i == 0 ? "" : ", ") + i;
        }
        stopwatch4String.Stop();
        return stopwatch4String.Elapsed.Ticks;
    }
}
