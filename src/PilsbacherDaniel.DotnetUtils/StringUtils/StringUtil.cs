using System.Globalization;

namespace PilsbacherDaniel.DotnetUtils.StringUtils;

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
        return text.Contains(compare, StringComparison.OrdinalIgnoreCase);
    }
}
