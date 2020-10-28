// Package leap enables the identification of leap years on Gregorian calendar dates.
package leap

// IsLeapYear returns true to a Gregoria calendar leap year, false otherwise.
func IsLeapYear(year int) bool {
	leapYear := year%4 == 0
	roundCenturyYear := year%100 == 0
	leapCentury := year%400 == 0

	return leapYear && !roundCenturyYear || leapCentury
}
