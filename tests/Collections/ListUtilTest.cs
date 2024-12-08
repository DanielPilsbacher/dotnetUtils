using src.Collections;
using System.Collections.Generic;

namespace tests.Collections;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetListOrEmptyTest()
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.That(ListUtil.GetListOrEmpty((List<string>)null), Is.Empty);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        List<string> tasks = new List<string>() { "Task 1: Create testcode for application", "Task 2: Validate businesscode" };
        Assert.That(ListUtil.GetListOrEmpty(tasks), Is.EqualTo(tasks));
    }
}