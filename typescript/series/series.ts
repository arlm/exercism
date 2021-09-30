export class Series {
  private readonly series: number[];

  constructor(series: string) {
    if (!series) {
      throw new Error('series cannot be empty');
    }

    this.series = series.split('').map(char => +char);
  }

  *generate(sliceLength: number): Iterable<number[]> {
    var index = 0;

    while (index + sliceLength <= this.series.length) {
      const endIndex = index + sliceLength;
      yield this.series.slice(index++, endIndex);
    }
  }

  slices(sliceLength: number): number[][] {
    if (sliceLength > this.series.length) {
      throw new Error('slice length cannot be greater than series length');
    }

    if (sliceLength == 0) {
      throw new Error('slice length cannot be zero');
    }

    if (sliceLength < 0) {
      throw new Error('slice length cannot be negative');
    }

    return Array.from(this.generate(sliceLength));
  }
}
