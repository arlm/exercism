using System;
using System.Collections.Generic;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) =>
        unchecked((int)Math.Pow(max.GetNumbersBefore().Sum(), 2));

    public static int CalculateSumOfSquares(int max) =>
        max.GetNumbersBefore().Sum(number => unchecked((int)Math.Pow(number, 2)));

    public static int CalculateDifferenceOfSquares(int max) =>
        CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

    public static IEnumerable<int> GetNumbersBefore(this int max)
    {
        for (int number = 1; number <= max; number++)
        {
            yield return number;
        }
    }
}