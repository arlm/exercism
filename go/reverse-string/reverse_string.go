package reverse

func Reverse(input string) string {
	runes := []rune(input)

	if input == "" {
		return input
	}

	result := ""

	for index := len(runes) - 1; index >= 0; index-- {
		result += string(runes[index])
	}

	return result
}
