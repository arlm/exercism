using System;
using System.Text.RegularExpressions;

public static class ScrabbleScore
{
    private const string LEVEL_1 = "[AEIOULNRST]";
    private const string LEVEL_2 = "[DG]";
    private const string LEVEL_3 = "[BCMP]";
    private const string LEVEL_4 = "[FHVWY]";
    private const string LEVEL_5 = "[K]";
    private const string LEVEL_8 = "[JX]";
    private const string LEVEL_10 = "[QZ]";

    public static int Score(string input)
    {
        var points = 0;

        points += Regex.Matches(input, LEVEL_1, RegexOptions.IgnoreCase).Count;
        points += Regex.Matches(input, LEVEL_2, RegexOptions.IgnoreCase).Count * 2;
        points += Regex.Matches(input, LEVEL_3, RegexOptions.IgnoreCase).Count * 3;
        points += Regex.Matches(input, LEVEL_4, RegexOptions.IgnoreCase).Count * 4;
        points += Regex.Matches(input, LEVEL_5, RegexOptions.IgnoreCase).Count * 5;
        points += Regex.Matches(input, LEVEL_8, RegexOptions.IgnoreCase).Count * 8;
        points += Regex.Matches(input, LEVEL_10, RegexOptions.IgnoreCase).Count * 10;

        return points;
    }
}