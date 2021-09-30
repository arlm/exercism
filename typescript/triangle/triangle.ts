export class Triangle {
  private readonly sides: number[]

  constructor(...sides: number[]) {
    this.sides = sides;
  }

  get isValid(): boolean {
    const [side1, side2, side3] = this.sides;
    return this.sides.every(side => side > 0)
            && side1 <= side2 + side3
            && side2 <= side1 + side3
            && side3 <= side2 + side1;
  }

  get isEquilateral(): boolean {
    return this.isValid && new Set(this.sides).size == 1;
  }

  get isIsosceles(): boolean {
    return this.isValid && new Set(this.sides).size <= 2;
  }

  get isScalene(): boolean {
    return this.isValid && new Set(this.sides).size == 3;
  }
}
