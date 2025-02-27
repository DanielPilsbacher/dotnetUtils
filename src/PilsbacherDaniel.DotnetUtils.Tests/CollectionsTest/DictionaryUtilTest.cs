using PilsbacherDaniel.DotnetUtils.Collections;

namespace PilsbacherDaniel.DotnetUtils.Tests.CollectionsTest;

#pragma warning disable

public class DictionaryUtilTest
{
    [Test]
    public void AddOrUpdateByKeyTest()
    {
        Dictionary<object, object> keyValues = null;
        // keyValues[1] = "Test 2"; // Line would cause [System.NullReferenceException : Object reference not set to an instance of an object.] // That's good!
        DictionaryUtil.AddOrUpdateByKey(keyValues, 1, "Test");      // assert no System.NullReferenceException
        keyValues = new Dictionary<object, object>();
        // keyValues[null] = "Test";                                // This line demonstrates a null value which would cause [System.ArgumentNullException : Value cannot be null. (Parameter 'key')] // That's good!
        DictionaryUtil.AddOrUpdateByKey(keyValues, null, "Test");   // assert no System.ArgumentNullException
        DictionaryUtil.AddOrUpdateByKey(keyValues, 1, "Test");      // add key=1 with value="Test"
        Assert.That(keyValues[1], Is.EqualTo("Test"));
        Assert.That(keyValues.Count, Is.EqualTo(1));
        DictionaryUtil.AddOrUpdateByKey(keyValues, 1, "Test 1");    // update key=1 with value="Test 1"3
        DictionaryUtil.AddOrUpdateByKey(keyValues, 2, "Test 2");    // add key=1 with value="Test 1"
        Assert.That(keyValues[1], Is.EqualTo("Test 1"));
        Assert.That(keyValues[2], Is.EqualTo("Test 2"));
        Assert.That(keyValues.Count, Is.EqualTo(2));
    }
}
