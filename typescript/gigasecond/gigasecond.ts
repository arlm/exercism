export class Gigasecond {
  private readonly secondsFromEpoch: number;

  constructor (date: Date) {
    this.secondsFromEpoch = date.getTime();
  }

  public date(): Date {
    return new Date(this.secondsFromEpoch + 1e12); // 1e9 * 1000 = 1e12
  }
}
