// Package twofer implements two for one. One for you and one for me.
package twofer

// ShareWith implements two for one. One for you and one for me.
// Given a name, return a string with the message: `One for X, one for me.`
func ShareWith(name string) string {
	switch {
	case len(name) > 0:
		return "One for " + name + ", one for me."
	default:
		return "One for you, one for me."
	}
}
