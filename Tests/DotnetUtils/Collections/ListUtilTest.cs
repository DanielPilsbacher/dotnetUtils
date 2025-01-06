using DotNetUtils.Collections;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace Tests.DotnetUtils.Collections
{
    public class ListUtilTest
    {
        [Test]
        public void GetListOrEmptyTest()
        {
            Assert.That(ListUtil.GetListOrEmpty((List<string>)null), Is.Empty);
            List<string> tasks = new List<string>() { "Task 1: Create testcode for application", "Task 2: Validate businesscode" };
            Assert.That(ListUtil.GetListOrEmpty(tasks), Is.EqualTo(tasks));
        }
    }
}

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
