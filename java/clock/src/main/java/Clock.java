class Clock {
  private int minutes;

  Clock(int hours, int minutes) {
    this.minutes = hours * 60 + minutes;
  }

  void add(int minutes) {
    this.minutes += minutes;
  }

  int getMinutes() {
    var adjustedMinutes = minutes < 0
        ? 60 + minutes % 60
        : minutes % 60;

    return adjustedMinutes == 60 ? 0 : adjustedMinutes;
  }

  int getHours() {
    var adjustedMinutes = minutes < 0
        ? 60 + minutes % 60
        : minutes % 60;

    var adjustedHourInMinutes = adjustedMinutes == 60
        ? minutes + 60
        : minutes;

    return adjustedHourInMinutes < 0
        ? 23 + (adjustedHourInMinutes / 60) % 24
        : (adjustedHourInMinutes / 60) % 24;
  }

  @Override
  public String toString() {
    return String.format("%02d:%02d", getHours(), getMinutes());
  }

  @Override
  public boolean equals(Object obj) {
    if (this == obj) {
      return true;
    }

    if (obj == null || obj.getClass() != this.getClass()) {
      return false;
    }

    var clock = (Clock) obj;
    return clock.getHours() == this.getHours()
        && clock.getMinutes() == this.getMinutes();
  }

  @Override
  public int hashCode() {
    int result = 17;
    result = 31 * result + getHours();
    return 31 * result + getMinutes();
  }
}
