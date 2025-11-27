using PilsbacherDaniel.DotnetUtils.Collections;

namespace PilsbacherDaniel.DotnetUtils.Tests.CollectionsTest;

public class XListTest
{
    [Test]
    public void Test()
    {
        XList<string> strings = [];
        strings[0] = "A";
        Assert.That(strings[0], Is.EqualTo("A"));
        strings[0] = "a";
        Assert.That(strings[0], Is.EqualTo("a"));
        strings[5] = "f";
        Assert.That(strings[5], Is.EqualTo("f"));
    }
}
