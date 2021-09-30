export class Squares {
  private readonly sequence: number[];

  constructor(count: number) {
    this.sequence = Array.from(this.generator(count));
  }

  get sumOfSquares(): number {
    return this.sequence.reduce((sum, value) => sum + value**2);
  }

  get squareOfSum(): number {
    return this.sequence.reduce((sum, value) => sum + value)**2;
  }

  get difference(): number {
    return this.squareOfSum - this.sumOfSquares;
  }

  private *generator(count: number): Iterable<number>  {
    var index = 1;
    while(index <= count){
      yield index++;
    }
  }
}
