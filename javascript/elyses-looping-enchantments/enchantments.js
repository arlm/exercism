// @ts-check

/**
 * Determine how many cards of a certain type there are in the deck
 *
 * @param {number[]} stack
 * @param {number} card
 *
 * @returns {number} number of cards of a single type there are in the deck
 */
export function cardTypeCheck(stack, card) {
  var counter = 0;

  for (let value of stack) {
    if (value == card) {
      counter++;
    }
  }
  
  return counter;
}

/**
 * Determine how many cards are odd or even
 *
 * @param {number[]} stack
 * @param {boolean} type the type of value to check for - odd or even
 * @returns {number} number of cards that are either odd or even (depending on `type`)
 */
export function determineOddEvenCards(stack, type) {
  var counter = 0;

    for (let value of stack) {
    if (value % 2 == 0) {
      counter++;
    }
  }
  
  return type ? counter : stack.length - counter;
}