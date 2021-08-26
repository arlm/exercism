//
// This is only a SKELETON file for the 'Resistor Color Trio' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

import { Console } from "console";

const colorCodes = {
  black : 0,
  brown : 1,
  red : 2,
  orange : 3,
  yellow : 4,
  green : 5,
  blue : 6,
  violet : 7,
  grey : 8,
  white : 9,
};


export class ResistorColorTrio {
  constructor(colors) {
    const value =  +('' + colorCodes[colors[0]] + colorCodes[colors[1]]) * 10 ** colorCodes[colors[2]];
    const exponent = Math.floor(Math.log10(value));
    const unit = Math.floor(exponent/ 3);

    if (Number.isNaN(unit)) {
      throw new Error("invalid color");
    }

    this.value = value /  10 ** (unit * 3);

    switch (unit) {
      case 0:
        this.unit = '';
        break;

      case 1:
        this.unit = 'kilo';
        break;

      case 2:
        this.unit = 'mega';
        break;

      case 3:
        this.unit = 'giga';
        break;
      }
  }

  get label() {
    return `Resistor value: ${this.value} ${this.unit}ohms`;
  }
}
