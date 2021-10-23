using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value) => TryFind(input, value, out var index) ? index : -1;

    public static bool TryFind(ArraySegment<int> input, int value, out int index)
    {
        index = -1;

        if (!input.Any())
        {
            return false;
        }

        var first = input[0];

        if (first == value)
        {
            index = input.Offset;
            return true;
        }

        if (input[0] > value)
        {
            return false;
        }

        var last = input.Last();

        if (last == value)
        {
            index = input.Offset + input.Count - 1;
            return true;
        }

        if (last < value)
        {
            return false;
        }

        var splitPoint = input.Count / 2;

        var middle = input[splitPoint];

        if (middle == value)
        {
            index = input.Offset + splitPoint;
            return true;
        }

        if (input.Count == 1)
        {
            return false;
        }

        if (middle > value)
        {
            var lowerSegment = input.GetSegment(..splitPoint);

            return TryFind(lowerSegment, value, out index);
        }

        var upperSegment = input.GetSegment((splitPoint + 1)..);
        return TryFind(upperSegment, value, out index);
    }

    public static ArraySegment<T> GetSegment<T>(this T[] array, Range range)
    {
        var index = range.Start.GetOffset(array.Length);
        var count = range.End.GetOffset(array.Length) - index;

        return count >= 0
            ? new ArraySegment<T>(array, index, count)
            : throw new ArgumentOutOfRangeException(nameof(range), $"Range should not be negative ({count}).");
    }

    public static ArraySegment<T> GetSegment<T>(this ArraySegment<T> array, Range range)
    {
        var index = range.Start.GetOffset(array.Count);
        var count = range.End.GetOffset(array.Count) - index;

        return count >= 0
            ? array.Slice(index, count)
            : throw new ArgumentOutOfRangeException(nameof(range), $"Range should not be negative ({count}).");
    }
}