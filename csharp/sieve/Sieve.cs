using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit) => EratosthenesSieve(limit).ToArray();

    public static IEnumerable<int> EratosthenesSieve(int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be bigger than zero.");
        }

        if (limit < 2)
        {
            yield break;
        }

        var sieve = new int[limit + 1];

        for (int number = 2; number <= limit; number++)
        {
            if (sieve[number] == 0)
            {
                yield return number;
                sieve[number] = number;
            }
            else
            {
                continue;
            }

            for (int multiple = 2; multiple <= limit; multiple++)
            {
                var result = number * multiple;

                if (result > limit)
                {
                    break;
                }

                sieve[result] = result;
            }
        }
    }
}