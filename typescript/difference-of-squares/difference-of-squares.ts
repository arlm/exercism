export class Squares {
  private count: number;

  constructor(count: number) {
    this.count = count;
  }

  get sumOfSquares(): number {
    var sum = 0;
    for (const value of this.generator()) {
      sum += value**2;
    }

    return sum;
  }

  get squareOfSum(): number {
    var sum = 0;
    for (const value of this.generator()) {
      sum += value;
    }

    return sum**2;
  }

  get difference(): number {
    return this.squareOfSum - this.sumOfSquares;
  }

  private *generator(): Iterable<number>  {
    var index = 1;
    while(index <= this.count){
      yield index++;
    }
  }
}
