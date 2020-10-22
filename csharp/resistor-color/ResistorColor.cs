
public static class ResistorColor
{
    private static readonly string[] colors = {
        "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"
    };

    public static int ColorCode(string color)
    {
        for(int index = 0; index < colors.Length; index++)
        {
            if (color == colors[index])
            {
                return index;
            }
        }

        return -1;
    }

    public static string[] Colors() => colors;
}