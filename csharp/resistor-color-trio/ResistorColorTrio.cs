using System;
using System.Linq;
using System.Text;

public static class ResistorColorTrio
{
    private static readonly string[] color_list = {
        "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"
    };

    public static string Label(string[] colors)
    {
        var value = Value(colors);

        return $"{ScientificNotation(value)}ohms";
    }

    private static string ScientificNotation(int value)
    {
        var exp = (int)Math.Log10(value);
        int sciExp;

        if (exp < 3)
        {
            sciExp = 0;
        }
        else if (exp < 6)
        {
            sciExp = 3;
        }
        else if (exp < 9)
        {
            sciExp = 6;
        }
        else
        {
            sciExp = 9;
        }

        var radix = value / Math.Pow(10, sciExp);

        string suffix;

        switch(sciExp)
        {
            case 0:
                suffix = string.Empty;
                break;
            case 3:
                suffix = "kilo";
                break;
            case 6:
                suffix = "mega";
                break;
            case 9:
                suffix = "giga";
                break;
            default:
                throw new ArgumentException($"Value {value} should not be bigger than 99e9.", nameof(value));
        }

        return $"{radix} {suffix}";
    }

    public static int Value(string[] colors)
    {
        var sb = new StringBuilder();

        foreach (var color in colors.Take(2))
        {
            sb.Append(ColorCode(color));
        }

        var zeroesReading = colors.Skip(2).First();
        var zeroes = ColorCode(zeroesReading);

        for(var count = 1; count <= zeroes; count++)
        {
            sb.Append(0);
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
