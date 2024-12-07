using System.Collections.Generic;

namespace src.Collections;

public class ListUtil
{
    public static List<T> GetListOrEmpty<T>(List<T> ts)
    {
        if (ts == null)
        {
            return new List<T>();
        }
        return ts;
    }
}
