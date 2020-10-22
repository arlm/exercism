using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var wink = (commandValue & 0b0001) != 0;
        var doubleBlink = (commandValue & 0b0010) != 0;
        var closeYourEyes = (commandValue & 0b0100) != 0;
        var jump = (commandValue & 0b1000) != 0;
        var reverse = (commandValue & 0b10000) != 0;

        var result = new List<string>(4);

        if (wink)
        {
            result.Add("wink");
        }

        if (doubleBlink)
        {
            result.Add("double blink");
        }

        if (closeYourEyes)
        {
            result.Add("close your eyes");
        }

        if (jump)
        {
            result.Add("jump");
        }

        if (reverse)
        {
            result.Reverse();
        }

        return result.ToArray();
    }
}
