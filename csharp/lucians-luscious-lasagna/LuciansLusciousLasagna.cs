class Lasagna
{
    internal int ExpectedMinutesInOven() => 40;

    internal int RemainingMinutesInOven(int timeInOven) => ExpectedMinutesInOven() - timeInOven;

    internal int PreparationTimeInMinutes(int layers) => layers * 2;

    internal int ElapsedTimeInMinutes(int layers, int timeInOven) => PreparationTimeInMinutes(layers) + timeInOven;
}
