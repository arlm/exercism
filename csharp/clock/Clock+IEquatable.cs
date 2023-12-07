using System;
using System.Diagnostics.CodeAnalysis;

public partial class Clock :
    IEquatable<Clock>,
    IEquatable<int>,
    IEquatable<long>,
    IEquatable<short>,
    IEquatable<decimal>,
    IEquatable<double>,
    IEquatable<float>
{
    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals([AllowNull] Clock other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Hours == other.Hours && Minutes == other.Minutes;
    }

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(int other) => ToMinutes() == other;

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(long other) => Convert.ToInt64(ToMinutes()) == other;

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(short other) => Convert.ToInt16(ToMinutes()) == other;

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(decimal other) => Convert.ToDecimal(ToMinutes()) == other;

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(double other) => Convert.ToDouble(ToMinutes()) == other;

    /// <summary>
    /// Compares the value of two different clocks.
    /// </summary>
    public bool Equals(float other) => Convert.ToSingle(ToMinutes()) == other;
}
