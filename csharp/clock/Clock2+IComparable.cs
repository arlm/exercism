using System;
using System.Diagnostics.CodeAnalysis;

public partial class Clock2 : IComparable, IComparable<Clock2>,
    IComparable<int>, IComparable<long>, IComparable<short>,
    IComparable<decimal>, IComparable<double>, IComparable<float>
{
    public int CompareTo(object other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is Clock2 clock)
        {
            return CompareTo(clock);
        }

        throw new ArgumentException("Cannot compare objects that are not Clocks.");
    }

    public int CompareTo([AllowNull] Clock2 other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (this == other)
        {
            return 0;
        }

        if (this > other)
        {
            return 1;
        }

        return -1;
    }

    public int CompareTo([AllowNull] int other)
    {
        var minutes = ToMinutes();

        return minutes.CompareTo(other);
    }

    public int CompareTo([AllowNull] float other)
    {
        var minutes = unchecked((float)ToMinutes());

        return minutes.CompareTo(other);
    }

    public int CompareTo([AllowNull] short other)
    {
        var minutes = unchecked((short) ToMinutes());

        return minutes.CompareTo(other);
    }

    public int CompareTo([AllowNull] long other)
    {
        var minutes = unchecked((long)ToMinutes());

        return minutes.CompareTo(other);
    }

    public int CompareTo([AllowNull] double other)
    {
        var minutes = unchecked((double)ToMinutes());

        return minutes.CompareTo(other);
    }

    public int CompareTo([AllowNull] decimal other)
    {
        var minutes = unchecked((decimal)ToMinutes());

        return minutes.CompareTo(other);
    }
}

