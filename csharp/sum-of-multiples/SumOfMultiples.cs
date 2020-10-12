using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) => GetMultiples(multiples, max).Sum();

    public static IEnumerable<int> GetMultiples(IEnumerable<int> multiples, int max)
    {
        for(int number = 0; number < max; number++)
        {
            if (multiples.Where(radix => radix > 0).Any(radix => number % radix == 0))
            {
                yield return number;
            }
        }
    }
}