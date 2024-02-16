(function() {
  var Leap;

  Leap = require('./leap');

  describe('Leap', function() {
    it('year not divisible by 4 is common year', function() {
      var result;
      result = Leap.leapYear(2015);
      return expect(result).toEqual(false);
    });
    it('year divisible by 2, not divisible by 4 is common year', function() {
      var result;
      result = Leap.leapYear(1970);
      return expect(result).toEqual(false);
    });
    it('year divisible by 4, not divisible by 100 is leap year', function() {
      var result;
      result = Leap.leapYear(1996);
      return expect(result).toEqual(true);
    });
    it('year divisible by 4 and 5 is still a leap year', function() {
      var result;
      result = Leap.leapYear(1960);
      return expect(result).toEqual(true);
    });
    it('year divisible by 100, not divisible by 400 is common year', function() {
      var result;
      result = Leap.leapYear(2100);
      return expect(result).toEqual(false);
    });
    it('year divisible by 100 but not by 3 is still not a leap year', function() {
      var result;
      result = Leap.leapYear(1900);
      return expect(result).toEqual(false);
    });
    it('year divisible by 400 is leap year', function() {
      var result;
      result = Leap.leapYear(2000);
      return expect(result).toEqual(true);
    });
    it('year divisible by 400 but not by 125 is still a leap year', function() {
      var result;
      result = Leap.leapYear(2400);
      return expect(result).toEqual(true);
    });
    return it('year divisible by 200, not divisible by 400 is common year', function() {
      var result;
      result = Leap.leapYear(1800);
      return expect(result).toEqual(false);
    });
  });

}).call(this);


//# sourceMappingURL=leap.spec.js.map
//# sourceURL=coffeescript