using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var cleanNumber = Regex.Replace(phoneNumber, @"(^\W*1|\W)", string.Empty);

        return Regex.IsMatch(cleanNumber, @"^[2-9][0-9]{2}[2-9][0-9]{6}$")
            ? cleanNumber
            : throw new ArgumentException($"Invalid NANP Number '{phoneNumber}'");
    }
}