using DotNetUtils.StringUtils;

namespace DotNetUtils.Test.StringUtils
{
    public class StringUtilTest
    {
        [Test]
        public void GetBytesTest()
        {
            byte[] bytes = StringUtil.GetBytes("ABCD");
            Assert.That(bytes.Length, Is.EqualTo(4));
        }
    }
}