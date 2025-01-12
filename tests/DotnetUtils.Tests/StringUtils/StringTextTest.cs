using System.Diagnostics;
using System.Reflection.Metadata;
using DotNetUtils.StringUtils;

namespace DotNetUtils.Test.StringUtils;

public class StringTextTest
{
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
        Console.WriteLine("Run unittest " + nameof(StringTextTest) + "." + nameof(PerformanceTest));
        bool passed = false;
        uint performancePercent = 0;
        for (int durationCounts = (int)Math.Exp(1); (durationCounts <= 25000) && !passed; durationCounts = (int)(Math.Exp(durationCounts)))
        {
            long stringConcatinationDurationTicks = GetStringConcatinationDurationTicks(durationCounts);
            long stringTextConcatinationDurationTicks = GetStringTextConcatinationDurationTicks(durationCounts);
            performancePercent = 100 * (uint)stringConcatinationDurationTicks / (uint)stringTextConcatinationDurationTicks;
            passed = performancePercent >= 100;
            Console.WriteLine("--  StringTextTest.PerformanceTest -----------------------------------------");
            Console.WriteLine(nameof(String) + " duration is     '" + stringConcatinationDurationTicks + "' ticks.");
            Console.WriteLine(nameof(StringText) + " duration is '" + stringTextConcatinationDurationTicks +  "' ticks.");
            Console.WriteLine("The performance is " + performancePercent + "% with '" + durationCounts + "' concatinations.");
            Console.WriteLine("Teststatus [" + (passed ? "PASSED" : "FAILED") + "]");
            Console.WriteLine("The duration for " + nameof(StringText) + " shall be less than for " + nameof(String) + ".");
            Console.WriteLine("----------------------------------------------------------------------------");
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
