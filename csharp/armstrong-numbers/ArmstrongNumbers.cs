using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int exponent = unchecked((int)Math.Log10(number));
        var digits = number.GetDigits(exponent);
        var sum = digits.Sum(digit => unchecked((int)Math.Pow(digit, exponent + 1)));

        return number == sum;
    }

    public static IEnumerable<int> GetDigits(this int number, int exponent)
    {
        var remaining = number;

        for (int factor = exponent; factor >= 0; factor--)
        {
            var digit = unchecked((int)Math.Pow(10, factor));
            var result = remaining / digit;
            remaining -= result * digit;

            yield return result;
        }
    }
}