using System;

public static class Darts
{
    private const int OUTER_CIRCLE = 10;
    private const int MIDDLE_CIRCLE = 5;
    private const int INNER_CIRCLE = 1;

    private const double EPSILON = 0.001;

    public static int Score(double x, double y)
    {
        var distance = DistanceFromCenter(x, y);

        if (distance.IsBiggerThan(OUTER_CIRCLE))
        {
            return 0;
        }

        if (distance.IsBiggerThan(MIDDLE_CIRCLE))
        {
            return 1;
        }

        if (distance.IsBiggerThan(INNER_CIRCLE))
        {
            return 5;
        }

        return 10;
    }

    private static double DistanceFromCenter(double x, double y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

    public static bool IsBiggerThan(this double value1, double value2) => value1 - value2 > EPSILON;
}
