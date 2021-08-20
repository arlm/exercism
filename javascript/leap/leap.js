//
// This is only a SKELETON file for the 'Leap' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const isLeap = (year) => {
  var isDivisibleBy4 = year % 4 === 0;
  var isDivisibleBy100 = year % 100 === 0;
  var isDivisibleBy400 = year % 400 === 0;

  return isDivisibleBy400 || (isDivisibleBy4 && !isDivisibleBy100);
};
