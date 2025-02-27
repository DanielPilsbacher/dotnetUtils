namespace PilsbacherDaniel.DotnetUtils.ByteUtils;

public static class ByteUtil
{
    public static byte[] GetBytes(string text)
    {
        List<byte> bytes = new List<byte>();
        foreach (char character in text ?? string.Empty)
        {
            bytes.Add((byte)character);
        }
        return bytes.ToArray();
    }
}
