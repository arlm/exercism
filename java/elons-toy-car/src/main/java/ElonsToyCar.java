public class ElonsToyCar {
  private final int speed = 20;

  private int distance = 0;
  private int battery = 100;

  public static ElonsToyCar buy() {
    return new ElonsToyCar();
  }

  public String distanceDisplay() {
    return String.format("Driven %d meters", distance);
  }

  public String batteryDisplay() {
    return battery == 0
        ? "Battery empty"
        : String.format("Battery at %d%%", battery);
  }

  public void drive() {
    if (battery > 0) {
      distance += speed;
      battery--;
    }
  }
}
