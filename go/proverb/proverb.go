// Package proverb provides a proverbial sequence of sentences given a list of items.
package proverb

import "fmt"

const (
	stanza = "For want of a %s the %s was lost."
	last   = "And all for the want of a %s."
)

// Proverb generates a sequence of proverbial sentences using the given items.
func Proverb(rhyme []string) []string {
	count := len(rhyme)
	result := make([]string, count)

	for index := range rhyme {
		if index+1 == count {
			result[index] = fmt.Sprintf(last, rhyme[0])
		} else {
			item1 := rhyme[index]
			item2 := rhyme[index+1]
			result[index] = fmt.Sprintf(stanza, item1, item2)
		}
	}

	return result
}
