package strand

import (
	"regexp"
)

// ToRNA transcribes the DNA nucleotides into RNA nucleotides
func ToRNA(dna string) string {
	response := []byte(dna)
	response = regexp.MustCompile(`A`).ReplaceAll(response, []byte("U"))
	response = regexp.MustCompile(`T`).ReplaceAll(response, []byte("A"))
	response = regexp.MustCompile(`G`).ReplaceAll(response, []byte("X"))
	response = regexp.MustCompile(`C`).ReplaceAll(response, []byte("G"))
	response = regexp.MustCompile(`X`).ReplaceAll(response, []byte("C"))
	return string(response)
}
