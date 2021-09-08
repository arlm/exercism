// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

/**
 * Calculates the total bird count.
 *
 * @param {number[]} birdsPerDay
 * @returns {number} total bird count
 */
export function totalBirdCount(birdsPerDay) {
  const sum = (accumulator, currentValue) => accumulator + currentValue;
  return birdsPerDay.reduce(sum);
}

/**
 * Calculates the total number of birds seen in a specific week.
 *
 * @param {number[]} birdsPerDay
 * @param {number} week
 * @returns {number} birds counted in the given week
 */
export function birdsInWeek(birdsPerDay, week) {
  const weekStart = 7 * (week - 1);
  const birdsInSelectedWeek = birdsPerDay.slice(weekStart, weekStart + 7);
  return totalBirdCount(birdsInSelectedWeek);
}

/**
 * Fixes the counting mistake by increasing the bird count
 * by one for every second day.
 *
 * @param {number[]} birdsPerDay
 * @returns {number[]} corrected bird count data
 */
export function fixBirdCountLog(birdsPerDay) {
  for (let index = 0; index <  birdsPerDay.length; index += 2) {
    birdsPerDay[index] += 1;
  }
  
  return birdsPerDay;
}
