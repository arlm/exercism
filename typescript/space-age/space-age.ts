enum Planets {
  mercury = 0.2408467,  // Earth years
  venus = 0.61519726,   // Earth years
  earth = 1.0,          // Earth years
  mars =  1.8808158,    // Earth years
  jupiter = 11.862615,  // Earth years
  saturn = 29.447498,   // Earth years
  uranus = 84.016846,   // Earth years
  neptune = 164.79132,  // Earth years
}

namespace Planets {
  export const SECONDS_PER_YEAR = 31557600;

  export function factor(this: any, planet: Planet): number {
    return Planets.SECONDS_PER_YEAR  * this[planet];
  }
}

type Planet = keyof typeof Planets;

export function age(planet: Planet, seconds: number): number {
  return +(seconds / Planets.factor(planet)).toFixed(2);
}
