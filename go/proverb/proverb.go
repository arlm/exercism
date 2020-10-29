// Package proverb provides a proverbial sequence of sentences given a list of items.
package proverb

import (
	"fmt"
)

// Proverb generates a sequence of proverbial sentences using the given items.
func Proverb(rhyme []string) []string {
	result := []string{}
	count := len(rhyme)

	for index := 0; index < count; index++ {
		var sentence string

		if index == count-1 {
			sentence = fmt.Sprintf("And all for the want of a %s.", rhyme[0])
		} else {
			item1 := rhyme[index]
			item2 := rhyme[index+1]
			sentence = fmt.Sprintf("For want of a %s the %s was lost.", item1, item2)
		}

		result = append(result, sentence)
	}

	return result
}
