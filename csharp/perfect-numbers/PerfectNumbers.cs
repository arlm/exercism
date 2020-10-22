using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException($"The number ({number}) must be greater than zero.", nameof(number));
        }

        var sum = number.GetDivisors().Sum();

        return  sum > number ?
            Classification.Abundant :
                sum < number ?
            Classification.Deficient :
            Classification.Perfect ;
    }

    public static IEnumerable<int> GetDivisors(this int number)
    {
        for (int divisor = 1; divisor <= number / 2; divisor++)
        {
            if (number % divisor == 0)
            {
                yield return divisor;
            }
        }
    }
}
