class RemoteControlCar
{
    internal int speed;
    internal readonly int batteryDrain;

    private int distance;
    internal int batteryStatus = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() =>
        batteryStatus < batteryDrain;

    public int DistanceDriven() => distance;

    public void Drive()
    {
        if (BatteryDrained()) {
            return;
        }

        batteryStatus -= batteryDrain;
        distance += speed;
    }

    public static RemoteControlCar Nitro() =>
        new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private readonly int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        var runs = 100 / car.batteryDrain;
        var distance = runs * car.speed;

        return distance >= this.distance;
    }
}
