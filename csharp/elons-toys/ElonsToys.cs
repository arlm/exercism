class RemoteControlCar
{
    private int batteryLevel = 100;
    private int distance = 0;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => batteryLevel == 0
        ? "Battery empty"
        : $"Battery at {batteryLevel}%";

    public void Drive()
    {
        if (batteryLevel == 0) {
            return;
        }

        batteryLevel--;
        distance += 20;
    }
}
