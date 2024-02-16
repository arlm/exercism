export function isLeap(year: number): boolean {
  return year.isDivisibleBy(100) ? year.isDivisibleBy(400) : year.isDivisibleBy(4);
}

declare global {
  interface Number {
    isDivisibleBy : (divisor: number) => boolean;
  }
}

Number.prototype.isDivisibleBy = function (divisor: number): boolean {
  return this.valueOf() % divisor === 0;
};
