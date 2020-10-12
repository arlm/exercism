using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0)
        {
            throw new ArgumentException("Invalid slice length, should be equal or lesser than the numbers length, but also bigger than zero.", nameof(sliceLength));
        }

        if (string.IsNullOrWhiteSpace(numbers))
        {
            throw new ArgumentException("Numbers should not be empty or null.", nameof(numbers));
        }

        return numbers.Slice(sliceLength).ToArray();
    }

    public static IEnumerable<string> Slice(this string numbers, int sliceLength)
    {
        var index = 0;
        var limit = numbers.Length - sliceLength;

        while(index <= limit)
        {
            var slice = numbers.Substring(index, sliceLength);
            index++;

            yield return int.TryParse(slice, out _)
                ? slice
                : throw new ArgumentException("There should be only numbers inside the string.", nameof(numbers));
        }
    }
}