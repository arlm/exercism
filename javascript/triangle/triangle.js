//
// This is only a SKELETON file for the 'Triangle' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Triangle {
  sides;
  isValid;

  constructor(...sides) {
    this.sides = sides;

    this.isValid = this.sides[0] > 0 
                && this.sides[1] > 0 
                && this.sides[2] > 0
                && this.sides[0] + this.sides[1] >= this.sides[2]
                && this.sides[0] + this.sides[2] >= this.sides[1]
                && this.sides[1] + this.sides[2] >= this.sides[0];
  }

  get isEquilateral() {
    return this.isValid
        && this.sides[0] == this.sides[1]
        && this.sides[0] == this.sides[2];
  }

  get isDegenerate() {
    return (this.sides[0] + this.sides[1]) == this.sides[2] 
        || (this.sides[0] + this.sides[2]) == this.sides[1]
        || (this.sides[1] + this.sides[2]) == this.sides[0]
;
  }

  get isIsosceles() {
    return this.isValid 
    && (
           this.sides[0] == this.sides[1]
        || this.sides[0] == this.sides[2]
        || this.sides[1] == this.sides[2]
    );
  }

  get isScalene() {
    return this.isValid
        && this.sides[0] != this.sides[1]
        && this.sides[0] != this.sides[2]
        && this.sides[1] != this.sides[2];
  }
}
