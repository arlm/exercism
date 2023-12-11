// This is a "stub" file.  It's a little start on your solution.
// It's not a complete solution though; you have to write some code.

// Package acronym should have a package comment that summarizes what it's about.
// https://golang.org/doc/effective_go.html#commentary
package acronym

import (
	"strings"
	"unicode"
)

// Abbreviate should have a comment documenting it.
func Abbreviate(s string) string {
	var input = strings.ReplaceAll(s, "-", " ")
	input = strings.ReplaceAll(input, "_", " ")
	var words []string = strings.Split(input, " ")
	var result string = ""

	for i := 0; i < len(words); i++ {
		var word string = words[i]

		if len(strings.TrimSpace(word)) == 0 {
			continue
		}

		var firstLetter byte = strings.ToUpper(word)[0]

		if unicode.IsLetter(rune(firstLetter)) {
			result += string(firstLetter)
		}
	}

	return result
}
