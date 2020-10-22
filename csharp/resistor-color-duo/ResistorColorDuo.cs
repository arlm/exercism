using System.Linq;
using System.Text;

public static class ResistorColorDuo
{
    private static readonly string[] color_list = {
        "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"
    };

    public static int Value(string[] colors)
    {
        var sb = new StringBuilder();

        foreach(var color in colors.Take(2))
        {
            sb.Append(ColorCode(color));
        }

        return int.Parse(sb.ToString());
    }

    public static int ColorCode(string color)
    {
        for (int index = 0; index < color_list.Length; index++)
        {
            if (color == color_list[index])
            {
                return index;
            }
        }

        return -1;
    }

    public static string[] Colors() => color_list;
}