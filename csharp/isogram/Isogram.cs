using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var distinctCount = word
            .ToLower()
            .Where(@char => char.IsLetter(@char))
            .Distinct().Count();

        var originalCount = word.
            Where(@char => char.IsLetter(@char))
            .Count();

        return distinctCount == originalCount;
    }
}
