// This class represents a year and determines if it is a leap year or not
class Leap {
    Integer year

    // The constructor takes a year as a parameter and assigns it to the instance field
    Leap(Integer year) {
        this.year = year
    }

    // This method returns true if the year is a leap year, false otherwise
    // A leap year occurs:
    // - In every year that is evenly divisible by 4
    // - Unless the year is evenly divisible by 100, in which case it's only a leap year if the year is also evenly divisible by 400
    def isLeapYear() {
        year % 100 == 0 ? year % 400 == 0 : year % 4 == 0
    }

}
