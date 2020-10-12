using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException("The number should be bigger than zero.", nameof(number));
        }

        var result = number;
        var steps = 0;

        while(result > 1)
        {
            steps++;

            if (result % 2 == 0)
            {
                result /= 2;
            }
            else
            {
                result = 3 * result + 1;
            }
        }

        return steps;
    }
}