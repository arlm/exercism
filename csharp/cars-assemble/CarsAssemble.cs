using System;

static class AssemblyLine
{
    private const int RATE_PER_HOUR = 221;

    public static double ProductionRatePerHour(int speed)
    {

        return RATE_PER_HOUR
            * speed
            * speed switch
            {
                >= 1 and <= 4 => 1,
                >= 5 and <= 8 => 0.9,
                9 => 0.8,
                10 => 0.77,
                _ => 0.0,
            };
    }

    public static int WorkingItemsPerMinute(int speed) => (int)Math.Floor(ProductionRatePerHour(speed) / 60);
}
