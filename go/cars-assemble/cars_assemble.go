package cars

import "math"

const IndividualCost = 10000
const BatchCost = 95000
const BatchSize = 10

// CalculateWorkingCarsPerHour calculates how many working cars are
// produced by the assembly line every hour.
func CalculateWorkingCarsPerHour(productionRate int, successRate float64) float64 {
	return float64(productionRate) * successRate / 100
}

// CalculateWorkingCarsPerMinute calculates how many working cars are
// produced by the assembly line every minute.
func CalculateWorkingCarsPerMinute(productionRate int, successRate float64) int {
	return int(math.Floor((CalculateWorkingCarsPerHour(productionRate, successRate) / float64(60.0))))
}

// CalculateCost works out the cost of producing the given number of cars.
func CalculateCost(carsCount int) uint {
	individualProduction := carsCount % BatchSize
	batchCost := (carsCount - individualProduction) / BatchSize * BatchCost
	return uint(batchCost + individualProduction*IndividualCost)
}
