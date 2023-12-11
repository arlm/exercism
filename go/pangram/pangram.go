package pangram

import (
	"regexp"
	"slices"
	"strings"
)

func IsPangram(input string) bool {
	alphabet := makeRange('a', 'z')

	re := regexp.MustCompile(`[a-zA-Z]`)
	letters := re.FindAllString(input, -1)

	if len(letters) == 0 {
		return false
	}

	for i := 0; i < len(alphabet); i++ {
		char := string(rune(alphabet[i]))
		if !slices.ContainsFunc(letters, func(item string) bool {
			return strings.ToLower(item) == char
		}) {
			return false
		}
	}

	return true
}

func makeRange(min, max int) []int {
	array := make([]int, max-min+1)

	for i := range array {
		array[i] = min + i
	}

	return array
}
