using src;
using System.Collections.Generic;

namespace tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetListOrEmptyTest()
    {
        Assert.That(ListUtil.GetListOrEmpty((List<string>)null), Is.Empty);
        List<string> tasks = new List<string>() { "Task 1: Create testcode for application", "Task 2: Validate businesscode" };
        Assert.That(ListUtil.GetListOrEmpty(tasks), Is.EqualTo(tasks));
    }
}