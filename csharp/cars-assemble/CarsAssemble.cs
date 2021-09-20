using System;

static class AssemblyLine
{
    private const int RATE_PER_HOUR = 221;

    public static double ProductionRatePerHour(int speed)
    {
        var successRate = 0.0;

        if (speed >= 1 && speed <= 4)
        {
            successRate = 1;
        } else if (speed >= 5 && speed <= 8)
        {
            successRate = 0.9;
        }
        else if (speed == 9)
        {
            successRate = 0.8;

        }
        else if (speed == 10)
        {
            successRate = 0.77;

        }

        return RATE_PER_HOUR * speed * successRate;
    }

    public static int WorkingItemsPerMinute(int speed) => (int)Math.Floor(ProductionRatePerHour(speed) / 60);
}
