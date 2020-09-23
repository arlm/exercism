using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class ClockComparer
{
    public static AscendingTimeComparer Ascending => new AscendingTimeComparer();
    public static DescendingTimeComparer Descending => new DescendingTimeComparer();
    public static DescendingHourAscendingMinutesComparer DescendingHourAscendingMinutes => new DescendingHourAscendingMinutesComparer();
}

/// <summary>
/// 00:00 01:00 01:30 01:45 02:00 02:30
/// </summary>
public class AscendingTimeComparer : IComparer<Clock>, IComparer
{
    public int Compare(object x, object y)
    {
        if (!(x is Clock one && y is Clock two))
        {
            throw new ArgumentException("Cannot compare objects that are not Clocks.");
        }

        return Compare(one, two);
    }

    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one > two)
        {
            return 1;
        }

        if (one < two)
        {
            return -1;
        }

        return 0;
    }
}

/// <summary>
/// 02:30 02:00 01:45 01:30 01:00 00:00
/// </summary>
public class DescendingTimeComparer : IComparer<Clock>, IComparer
{
    public int Compare(object x, object y)
    {
        if (!(x is Clock one && y is Clock two))
        {
            throw new ArgumentException("Cannot compare objects that are not Clocks.");
        }

        return Compare(one, two);
    }

    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one > two)
        {
            return -1;
        }

        if (one < two)
        {
            return 1;
        }

        return 0;
    }
}

/// <summary>
/// 02:00 02:30 01:00 01:30 01:45 00:00
/// </summary>
public class DescendingHourAscendingMinutesComparer : IComparer<Clock>, IComparer
{
    public int Compare(object x, object y)
    {
        if (!(x is Clock one && y is Clock two))
        {
            throw new ArgumentException("Cannot compare objects that are not Clocks.");
        }

        return Compare(one, two);
    }

    public int Compare([AllowNull] Clock one, [AllowNull] Clock two)
    {
        if (one.Hours > two.Hours)
        {
            return -1;
        }

        if (one.Hours < two.Hours)
        {
            return 1;
        }

        if (one.Minutes > two.Minutes)
        {
            return 1;
        }

        if (one.Minutes < two.Minutes)
        {
            return -1;
        }

        return 0;
    }
}
