class ClockData {
  private readonly _hour: number;
  private readonly _minute: number;

  constructor(hour: number = 0, minute: number = 0) {
    this._hour = hour;
    this._minute = minute;
  }

  public get hour() {return this._hour};
  public get minute() {return this._minute};

  public equals(other: ClockData): boolean {
    return this._hour == other._hour && this._minute == other._minute;
  }
}

export class Clock {
  private readonly clock: ClockData;

  constructor(hour: number, minute: number = 0) {
    const minutesClock = this.adjustMinutes(minute);
    const adjustedHour = this.adjustHours(hour + minutesClock.hour)

    this.clock = new ClockData(adjustedHour, minutesClock.minute);
  }

  private adjustMinutes(minutes: number): ClockData {
    const adjustedMinute = minutes < 0 
      ? 60 + minutes % 60
      : minutes % 60;
    
    var hours = Math.trunc(minutes / 60);

    if (minutes < 0) {
      hours--;
    }

    const adjustedHour = hours < 0 
    ? 24 + hours % 24
    : hours;

    return new ClockData(adjustedHour, adjustedMinute);
  }

  private adjustHours(hours: number): number {
    return hours < 0 
            ? 24 + hours % 24
            : hours % 24;
  }

  public toString(): string {
    const hours = this.clock.hour.toString().padStart(2, '0');
    const minutes = this.clock.minute.toString().padStart(2, '0');
    return `${hours}:${minutes}`;
  }

  public plus(minutes: number): Clock {
    const minutesClock = this.adjustMinutes(this.clock.minute + minutes);
    const adjustedHour = this.adjustHours(this.clock.hour + minutesClock.hour)
    
    return new Clock(adjustedHour, minutesClock.minute);
  }

  public minus(minutes: number): Clock {
    const minutesClock = this.adjustMinutes(this.clock.minute - minutes);
    const adjustedHour = this.adjustHours(this.clock.hour + minutesClock.hour)
    
    return new Clock(adjustedHour, minutesClock.minute);
  }

  public equals(other: Clock): boolean {
    return this.clock.equals(other.clock);
  }
}
