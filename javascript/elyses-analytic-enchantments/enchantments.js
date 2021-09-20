// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

/**
 * Get the position (index) of the card in the given stack
 *
 * @param {number[]} stack
 * @param {number} card
 *
 * @returns {number} position of the card in the stack
 */
export function getCardPosition(stack, card) {
  return stack.indexOf(card);
}

/**
 * Determine if the stack contains the card
 *
 * @param {number[]} stack
 * @param {number} card
 *
 * @returns {boolean} true if card is in the stack, false otherwise
 */
export function doesStackIncludeCard(stack, card) {
  return stack.indexOf(card) >= 0;
}

/**
 * Determine if each card is even
 *
 * @param {number[]} stack
 *
 * @returns {boolean} position of the first card that is even
 */
export function isEachCardEven(stack) {
  return stack.every((value, _index, _array) => value % 2 == 0);
}

/**
 * Check if stack contains odd-value card
 *
 * @param {number[]} stack
 *
 * @returns {boolean} Whether array contains odd card
 */
export function doesStackIncludeOddCard(stack) {
  return stack.findIndex((value, _index) => value % 2 != 0) >= 0;
}

/**
 * Get the first odd card from the stack
 *
 * @param {number[]} stack
 *
 * @returns {number} the first odd value
 */
export function getFirstOddCard(stack) {
  return stack.find((value, _index) => value % 2 != 0);
}

/**
 * Determine the position of the first card that is even
 *
 * @param {number[]} stack
 *
 * @returns {number} position of the first card that is even
 */
export function getFirstEvenCardPosition(stack) {
  return stack.findIndex((value, _index) => value % 2 == 0);
}