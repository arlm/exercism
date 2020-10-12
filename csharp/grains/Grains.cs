using System;

public static class Grains
{
    public static ulong Square(int n) =>
        n <= 0 || n > 64
            ? throw new ArgumentOutOfRangeException("The numbers of square should be between 1 and 64.", nameof(n))
            : (ulong)Math.Pow(2, n - 1);

    public static ulong Total() => unchecked((ulong) Math.Pow(2, 64) - 1);
}