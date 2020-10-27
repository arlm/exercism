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
	aRunes := []rune(a)
	bRunes := []rune(b)

	for index, aRuneValue := range aRunes {
		bRuneValue := bRunes[index]
		aWidth := utf8.RuneLen(aRuneValue)
		bWidth := utf8.RuneLen(bRuneValue)

		if aRuneValue != bRuneValue || aWidth != bWidth {
			count++
		}
	}

	return count, nil
}
