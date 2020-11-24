package raindrops

import "strconv"

// Convert a number to a string using Pling, Plang, Plong or a number as string
func Convert(drops int) string {
	result := ""
	divisibleBy3 := drops%3 == 0
	divisibleBy5 := drops%5 == 0
	divisibleBy7 := drops%7 == 0

	if divisibleBy3 {
		result += "Pling"
	}

	if divisibleBy5 {
		result += "Plang"
	}

	if divisibleBy7 {
		result += "Plong"
	}

	if !divisibleBy7 && !divisibleBy5 && !divisibleBy3 {
		result = strconv.Itoa(drops)
	}

	return result
}
