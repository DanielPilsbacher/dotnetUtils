namespace DotNetUtils.Collections;

/// <summary>
/// Common development methods for Dictionary
/// </summary>
public class DictionaryUtil
{
    /// <summary>
    /// The method updates a given key or adds if it's firstly assigned.<br />
    /// Is also checks if the dictionary is initatlized. <br />
    /// The intention is to avoid <see cref="System.ArgumentNullException"/> causing damage to the use case if a dictionary or a key with null can not be guaranteed during runtime.<br />
    /// Also consider alternative solutions like try-catch, codereviewing and further techniques.<br />
    /// Example foreach-loop:
    /// <code>
    /// ////////////////////////////////////////////////////////////////////
    /// Dictionary<int, string> keyValues = new Dictionary<int, string>();
    /// keyValues[2] = "Entry 2";   // OK here but whats with [1] and [2].
    /// Assert.That(keyValues[1], Is.Null);
    /// {
    ///     // do awesome stuff
    /// }
    /// ////////////////////////////////////////////////////////////////////
    /// </code>
    /// </summary>
    /// <typeparam name="TKey">Any type for <paramref name="key"/>. If null no assignement will happen.</typeparam>
    /// <typeparam name="TValue">Any type for <paramref name="value"/>.</typeparam>
    /// <param name="dictionary">Dictionary to operate with <see cref="TKey"/> and <seealso cref="TValue"/>. If null no assignement will happen.</param>
    /// <param name="key">Key object for <paramref name="dictionary"/>.</param>
    /// <param name="value">Value object for <paramref name="dictionary"/>.</param>
    public static void AddOrUpdateByKey<TKey, TValue>(Dictionary<TKey,TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        if (dictionary == null || key == null)
        {
            return;
        }
        dictionary[key] = value;
    }
}
