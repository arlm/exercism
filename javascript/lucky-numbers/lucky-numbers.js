// @ts-check

/**
 * Calculates the sum of the two input arrays.
 *
 * @param {number[]} array1
 * @param {number[]} array2
 * @returns {number} sum of the two arrays
 */
export function twoSum(array1, array2) {
  const number1 = +array1.map(number => number.toFixed(0)).reduce((accumulator, number) => accumulator + number);
  const number2 = +array2.map(number => number.toFixed(0)).reduce((accumulator, number) => accumulator + number);
  return number1 + number2;
}

/**
 * Checks whether a number is a palindrome.
 *
 * @param {number} value
 * @returns {boolean}  whether the number is a palindrome or not
 */
export function luckyNumber(value) {
  const reverse = +value.toFixed(0).split("").reverse().join("");

  return value == reverse;
}

/**
 * Determines the error message that should be shown to the user
 * for the given input value.
 *
 * @param {string|null|undefined} input
 * @returns {string} error message
 */
export function errorMessage(input) {
  var number = +input;

  if (number) {
    return '';
  }

  if (!input) {
    return 'Required field';
  }

  return 'Must be a number besides 0';
}
