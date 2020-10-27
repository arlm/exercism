package hamming

import (
	"errors"
	"unicode/utf8"
)

// Distance calculates the Hamming distance of two DNA strands
func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return 0, errors.New("both strands should be of the same size")
	}

	count := 0

	for index, aRuneValue := range a {
		aWidth := utf8.RuneLen(aRuneValue)
		bRuneValue, bWidth := utf8.DecodeRuneInString(b[index:])

		if aRuneValue != bRuneValue || aWidth != bWidth {
			count++
		}
	}

	return count, nil
}
