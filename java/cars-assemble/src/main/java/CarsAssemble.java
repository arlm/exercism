import java.security.InvalidParameterException;

public class CarsAssemble {
  private static final int production = 221;

  public double productionRatePerHour(int speed) {
    if (speed < 0 || speed > 10) {
      throw new InvalidParameterException("Speed should be between 0 and 10");
    }

    double successRate = 1.0;

    if (speed >= 5 && speed <= 8) {
      successRate = 0.9;
    } else if (speed == 9) {
      successRate = 0.8;
    } else if (speed == 10) {
      successRate = 0.77;
    }

    return speed * production * successRate;
  }

  public int workingItemsPerMinute(int speed) {
    return (int) Math.floor(productionRatePerHour(speed) / 60.0);
  }
}
