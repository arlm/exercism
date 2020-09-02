using System;

using Xunit.Sdk;

public static class ResistorColor
{
    static string[] cores = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color)
    {
        for(int index = 0; index < cores.Length; index++)
        {
            if (color == cores[index])
            {
                return index;
            }
        }

        return -1;
    }

    public static string[] Colors()
    {
        return cores;
    }
}