// @ts-check
//
// ☝🏽 The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion on the web
// and supported IDEs when implementing this exercise. You don't need to
// understand types, JSDoc, or TypeScript in order to complete this JavaScript
// exercise, and can completely ignore this comment block and directive.

// 👋🏽 Hi again!
//
// A quick reminder about exercise stubs:
//
// 💡 You're allowed to completely clear any stub before you get started. Often
// we recommend using the stub, because they are already set-up correctly to
// work with the tests, which you can find in ./freelancer-rates.spec.js.
//
// 💡 You don't need to write JSDoc comment blocks yourself; it is not expected
// in idiomatic JavaScript, but some companies and style-guides do enforce them.
//
// Get those rates calculated!

let hoursPerDay = 8;
let daysPerMonth = 22;

/**
 * The day rate, given a rate per hour
 *
 * @param {number} ratePerHour
 * @returns {number} the rate per day
 */
export function dayRate(ratePerHour) {
  return ratePerHour * hoursPerDay;
};

/**
 * Calculates the rate per month
 *
 * @param {number} ratePerHour
 * @param {number} discount for example 20% written as 0.2
 * @returns {number} the rounded up monthly rate
 */
export function monthRate(ratePerHour, discount) {
  return Math.ceil(daysPerMonth * applyDiscount(dayRate(ratePerHour), discount));
};

/**
 * Calculates the number of days in a budget, rounded down
 *
 * @param {number} budget the total budget
 * @param {number} ratePerHour the rate per hour
 * @returns {number} the number of days
 */
export function daysInBudget(budget, ratePerHour) {
  return Math.floor(budget / applyDiscount(dayRate(ratePerHour), 0));
};

/**
 * Calculates the number of days in a budget, rounded down
 *
 * @param {number} ratePerHour the rate per hour
 * @param {number} days the bumber of worked days
 * @param {number} discount to apply, example 20% written as 0.2
 * @returns {number} the number of days
 */
export function priceWithMonthlyDiscount(ratePerHour, days, discount) {
  let remainingDays =days % daysPerMonth;
  let fullMonths = days - remainingDays;
  let dailyRate = dayRate(ratePerHour);
  return Math.ceil(fullMonths * applyDiscount(dailyRate, discount)) + remainingDays * dailyRate;
};

/**
 * Applies a discount to the value
 *
 * @param {number} value
 * @param {number} percentage for example 20% written as 0.2
 * @returns {number} the discounted value
 */
function applyDiscount(value, percentage) {
  return value * (1 - percentage);
};
