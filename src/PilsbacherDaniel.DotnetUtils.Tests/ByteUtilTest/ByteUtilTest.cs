using PilsbacherDaniel.DotnetUtils.ByteUtils;

namespace PilsbacherDaniel.DotnetUtils.Tests.ByteUtilTest;

#pragma warning disable

public class ByteUtilTest
{
    [Test]
    public void GetBytesTest()
    {
        byte[] bytes = ByteUtil.GetBytes("ABCD");
        Assert.That(bytes.Length, Is.EqualTo(4));
    }
}
