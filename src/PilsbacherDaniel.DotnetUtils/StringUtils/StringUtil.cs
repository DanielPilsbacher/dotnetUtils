namespace PilsbacherDaniel.DotnetUtils.ByteUtils;

public static class StringUtil
{
    public static bool ContainsIgnoreCase(string text, string compare)
    {
        if (text == null)
        {
            return false;
        }
        if (compare == null)
        {
            return false;
        }
        return text.ToLower().CompareTo(compare.ToLower()) == 0;
    }
}
