// Package weather provides weather forecast for specific cities and locations.
package weather

// CurrentCondition stores the current condition forecast for a specific location
// designated by the CurrentLocation variable.
var CurrentCondition string

// CurrentLocation stores the location for the current forecast.
var CurrentLocation string

// Forecast returns a string containing the forecast for a specific city with
// a specified condition. The parameter city and conditionn are strings containing
// the appropriate location and condition for the forecast.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
