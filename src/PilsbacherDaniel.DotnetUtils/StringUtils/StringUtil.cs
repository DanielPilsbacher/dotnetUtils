using System.Globalization;

namespace PilsbacherDaniel.DotnetUtils.StringUtils;

public static class StringUtil
{
    public static bool ContainsIgnoreCase(string text, string compare, CultureInfo? cultureInfo = null)
    {
        if (text == null)
        {
            return false;
        }
        if (compare == null)
        {
            return false;
        }
        return text.ToLower(cultureInfo).CompareTo(compare.ToLower(cultureInfo)) == 0;
    }
}
