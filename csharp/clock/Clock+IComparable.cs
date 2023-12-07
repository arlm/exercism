using System;
using System.Diagnostics.CodeAnalysis;

public partial class Clock :
    IComparable,
    IComparable<Clock>,
    IComparable<int>,
    IComparable<long>,
    IComparable<short>,
    IComparable<decimal>,
    IComparable<double>,
    IComparable<float>
{
    public int CompareTo(object other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is Clock clock)
        {
            return CompareTo(clock);
        }

        throw new ArgumentException("Cannot compare objects that are not Clocks.");
    }

    public int CompareTo([AllowNull] Clock other)
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

    public int CompareTo(int other) => ToMinutes().CompareTo(other);

    public int CompareTo(float other) => Convert.ToSingle(ToMinutes()).CompareTo(other);

    public int CompareTo(short other) => Convert.ToInt16(ToMinutes()).CompareTo(other);

    public int CompareTo(long other) => Convert.ToInt64(ToMinutes()).CompareTo(other);

    public int CompareTo(double other) => Convert.ToDouble(ToMinutes()).CompareTo(other);

    public int CompareTo(decimal other) => Convert.ToDecimal(ToMinutes()).CompareTo(other);
}

