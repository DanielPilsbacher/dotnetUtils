namespace DotNetUtils.Collections;

public class ListUtil
{
    /// <summary>
    /// The method guarantees an initialized list if (at runtime) ts could be null.<br />
    /// The intention is to avoid <see cref="System.ArgumentNullException"/> causing damage to the use case if a List with null can not be guaranteed.<br />
    /// Consider alternative solutions like try-catch, codereviewing and further techniques.<br />
    /// Example foreach-loop:
    /// <code>
    /// ////////////////////////////////////////////////////////////////////
    /// // Possible (!) runtime-exception because 'strings' is null
    /// foreach (string item in strings)
    /// {
    ///     // do awesome stuff
    /// }
    /// ////////////////////////////////////////////////////////////////////
    /// // No runtime-exception even if 'strings' is null
    /// foreach (string item in ListUtil.GetListOrEmpty(strings))
    /// {
    ///     // do awesome stuff
    /// }
    /// ////////////////////////////////////////////////////////////////////
    /// </code>
    /// </summary>
    /// <typeparam name="T">any type T</typeparam>
    /// <param name="ts">List parameter that might be null.</param>
    /// <returns>Parameter ts or an empty List&lt;T&gt; if is null is returned.</returns>
    public static List<T> GetListOrEmpty<T>(List<T> ts)
    {
        if (ts == null)
        {
            return new List<T>();
        }
        return ts;
    }
}
