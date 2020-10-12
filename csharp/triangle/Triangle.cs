using System;

public static class Triangle
{
    private const double EPSILON = 0.000001;

    public static bool IsDegenerate(double side1, double side2, double side3)
    {
        if (!CheckArguments(side1, side2, side3))
        {
            return false;
        }

        var comparison1 = Math.Abs(side1 + side3 - side2) < EPSILON;
        var comparison2 = Math.Abs(side1 + side2 - side3) < EPSILON;
        var comparison3 = Math.Abs(side2 + side3 - side1) < EPSILON;

        return comparison1 || comparison2 || comparison3;
    }

    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!CheckArguments(side1, side2, side3))
        {
            return false;
        }

        var comparison1 = Math.Abs(side1 - side2) < EPSILON;
        var comparison2 = Math.Abs(side2 - side3) < EPSILON;
        var comparison3 = Math.Abs(side1 - side3) < EPSILON;

        return !comparison1 && !comparison2! && !comparison3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (!CheckArguments(side1, side2, side3))
        {
            return false;
        }

        var comparison1 = Math.Abs(side1 - side2) < EPSILON;
        var comparison2 = Math.Abs(side2 - side3) < EPSILON;
        var comparison3 = Math.Abs(side1 - side3) < EPSILON;

        return  comparison1 || comparison2 || comparison3;
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (!CheckArguments(side1, side2, side3))
        {
            return false;
        }

        var comparison1 = Math.Abs(side1 - side2) < EPSILON;
        var comparison2 = Math.Abs(side2 - side3) < EPSILON;

        return comparison1 && comparison2;
    }

    private static bool CheckArguments(double side1, double side2, double side3)
    {
        if (side1 <= 0)
        {
            return false;
        }

        if (side2 <= 0)
        {
            return false; 
        }

        if (side3 <= 0)
        {
            return false;
        }

        var comparison1 = side1 + side2 >= side3;
        var comparison2 = side1 + side3 >= side2;
        var comparison3 = side2 + side3 >= side1;

        return comparison1 && comparison2 && comparison3;
    }
}