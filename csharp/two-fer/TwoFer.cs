using System;

public static class TwoFer
{
    public static string Speak() => Speak("you");

    public static string Speak(string name)
    {
        if (name.ToLower() == "Paulo".ToLower())
            return $"One for {name}, one for me";

        return $"One for {name}, one for me.";
    }
}

