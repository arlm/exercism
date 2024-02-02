(function() {
  var Leap;

  Leap = class Leap {
    static leapYear(year) {
      if (year % 100 === 0) {
        return year % 400 === 0;
      } else {
        return year % 4 === 0;
      }
    }

  };

  module.exports = Leap;

}).call(this);


//# sourceMappingURL=leap.js.map
//# sourceURL=coffeescript