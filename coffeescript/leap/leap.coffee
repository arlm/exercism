class Leap
  @leapYear: (year) -> if year % 100 == 0 then year % 400 == 0 else year % 4 == 0

module.exports = Leap
