using NLog;
using PilsbacherDaniel.DotnetUtils.StringUtils;

namespace PilsbacherDaniel.DotnetUtils.Tests.StringUtilsTest
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
