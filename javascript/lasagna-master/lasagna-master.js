/// <reference path="./global.d.ts" />
// @ts-check

/**
 * Implement the functions needed to solve the exercise here.
 * Do not forget to export them so they are available for the
 * tests. Here an example of the syntax as reminder:
 *
 * export function yourFunction(...) {
 *   ...
 * }
 */

/**
 * Determines cooking status of the lasagna.
 *
 * @param {number|null|undefined} timer Tme that it has been on the oven
 * @returns {string} The status message
 */
export function cookingStatus(timer) {
    if (timer === 0) {
        return 'Lasagna is done.';
    }

    if (!timer) {
        return 'You forgot to set the timer.';
    }

    return 'Not done, please wait.';
}

/**
 * @typedef {Object} Quantities Quantities of noodles and sauce.
 * @property {number} noodles Amount of noodles in grams
 * @property {number} sauce Amount of sauce in liters
 */

/**
 * Determines preparation time of the lasagna.
 *
 * @param {array} layers List of layers
 * @param {number} preparationTime Average preparation time in minutes
 * @returns {number} Total preparation time in minutes
 */
 export function preparationTime(layers, preparationTime = 2) {
     return layers.length * preparationTime;
 }

 /**
 * Determines the amount of sauce and noodles needed to make the lasagna.
 *
 * @param {array} layers List of layers
 * @returns {Quantities} Quantities of noodles and sauce
 */
  export function quantities(layers) {
      var noodles = layers.filter(layer => layer.toLowerCase() == 'noodles' ).length;
      var sauce = layers.filter(layer => layer.toLowerCase() == 'sauce' ).length;;

    return { noodles: noodles * 50, sauce: sauce * 0.2 };
}

/**
 * Determines preparation time of the lasagna.
 *
 * @param {array} friendsLayers List of layers from friends
 * @param {array} myLayers My list of layers
 */
 export function addSecretIngredient(friendsLayers, myLayers) {
    myLayers.push(friendsLayers[friendsLayers.length - 1]);
 }

/**
 * Determines preparation time of the lasagna.
 *
 * @param {Object} recipe The amounts needed for 2 portions
 * @param {number} portions The number of portions you want to cook
 * @returns {Object} Quantities for this recipe
 */
 export function scaleRecipe(recipe, portions) {
    const result = {}

    const ratio = portions / 2;

    for (const item in recipe) {
        result[item] = recipe[item] *  ratio;
    }

    return result;
 }