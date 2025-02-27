using NLog;
using PilsbacherDaniel.DotnetUtils.ByteUtils;
using PilsbacherDaniel.DotnetUtils.Tests;

namespace PilsbacherDaniel.DotnetUtils.StringUtils
{
    internal class StringUtilsTest : TestBase
    {
        public StringUtilsTest() : base(LogManager.GetCurrentClassLogger())
        {
        }

        [Test]
        public void ContainsIgnoreCaseTest()
        {
            Assert.That(StringUtil.ContainsIgnoreCase("ABC", "ABC"));
            Assert.That(StringUtil.ContainsIgnoreCase("ABC", "Abc"));
            Assert.That(StringUtil.ContainsIgnoreCase("ABC", "aBc"));
            Assert.That(StringUtil.ContainsIgnoreCase("ABC", "abc"));
        }
    }
}
