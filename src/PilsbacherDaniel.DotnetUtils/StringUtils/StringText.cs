using System.Text;

namespace PilsbacherDaniel.DotnetUtils.StringUtils;

public class StringText
{
    public StringBuilder StringBuilder { get; internal set; }

    public static implicit operator StringText(string text)
    {
        return new StringText(text);
    }

    private StringText(string text)
    {
        StringBuilder = new StringBuilder(text);
    }

    public static StringText operator +(StringText stringText1, StringText stringText2)
    {
        stringText1.StringBuilder.Append(stringText2);
        return stringText1;
    }

    public override string ToString()
    {
        return StringBuilder.ToString();
    }
}
