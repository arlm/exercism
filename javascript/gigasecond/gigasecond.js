//
// This is only a SKELETON file for the 'Gigasecond' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const gigasecond = (initialDate) => {
  // Date.getTime() retorna o número de milisegundos desde 'epoch' (1 de Janeiro de 1970, 00:00:00 UTC)
   var secondsFromEpoch = initialDate.getTime() / 1000;
   var result = new Date((secondsFromEpoch + 1e9) * 1000);
  return result;
};
