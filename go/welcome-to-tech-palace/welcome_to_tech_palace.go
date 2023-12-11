package techpalace

import (
	"strings"
)

// WelcomeMessage returns a welcome message for the customer.
func WelcomeMessage(customer string) string {
	return "Welcome to the Tech Palace, " + strings.ToUpper(customer)
}

// AddBorder adds a border to a welcome message.
func AddBorder(welcomeMsg string, numStarsPerLine int) string {
	result := MakeBorder(numStarsPerLine)
	result += "\n"
	result += welcomeMsg
	result += "\n"
	result += MakeBorder(numStarsPerLine)

	return result
}

// CleanupMessage cleans up an old marketing message.
func CleanupMessage(oldMsg string) string {
	result := strings.ReplaceAll(oldMsg, "*", "")
	result = strings.ReplaceAll(result, "\n", "")
	result = strings.TrimSpace(result)
	return result
}

func MakeBorder(count int) string {
	result := ""

	for i := 0; i < count; i++ {
		result += "*"
	}

	return result
}
