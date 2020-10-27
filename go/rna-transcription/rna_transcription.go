package strand

import "strings"

var transcriber = strings.NewReplacer(
	"G", "C",
	"C", "G",
	"T", "A",
	"A", "U",
)

// ToRNA transcribes the DNA nucleotides into RNA nucleotides
func ToRNA(dna string) string {
	return transcriber.Replace(dna)
}
