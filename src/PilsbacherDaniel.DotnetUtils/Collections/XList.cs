namespace PilsbacherDaniel.DotnetUtils.Collections;

public class XList<T> : List<T>
{
    public new T this[int index]
    {
        get
        {
            return base[index];
        }

        set
        {
            if (index == Count)
            {
                Add(value);
            }
            if (index >= Count)
            {
                int count = Count;    // counter migth change by adding values
                for (int i = 0; i <= index - count; i++)
                {
                    Add(default!);
                }
            }
            base[index] = value;
        }
    }
}
