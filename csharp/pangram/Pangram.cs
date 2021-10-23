using System;
using System.Linq;


public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var usedLetters = input?
            .Where(@char => char.IsLetter(@char))
            .Select(@char => char.ToLower(@char))
            .Distinct()
            ?? throw new ArgumentNullException(nameof(input));

        return usedLetters.Count() == 26;
    }
}
