//
// This is only a SKELETON file for the 'Space Age' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const age = (planet, ageInSeconds) => {
  const dayInSeconds = 24 * 60 * 60;       // 1 Earth day = 86400 seconds;
  const earthYear = dayInSeconds * 365.25; // 1 Earth year = 365.25 Earth days, or 31557600 seconds
  const earthAge = ageInSeconds / earthYear;
  var factor;

  switch (planet) {
    case "earth":
      factor = 1;
      break;

    case "mercury":
      factor = 0.2408467;
      break;

    case "venus":
      factor = 0.61519726;
      break;

    case "mars":
      factor = 1.8808158;
      break;

    case "jupiter":
      factor = 11.862615;
      break;

    case "saturn":
      factor = 29.447498;
      break;

    case "uranus":
      factor = 84.016846;
      break;

    case "neptune":
      factor = 164.79132;
      break;

    default:
      throw "Parâmetro inválido";
  }

  const age = earthAge / factor;

  return +(age.toFixed(2));
};
