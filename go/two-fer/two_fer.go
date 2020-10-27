// Package twofer implements two for one. One for you and one for me.
package twofer

// ShareWith implements two for one. One for you and one for me.
// Given a name, return a string with the message: `One for X, one for me.`
func ShareWith(name string) string {
	if len(name) == 0 {
		name = "you"
	}

	return "One for " + name + ", one for me."
}
