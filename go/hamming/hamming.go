package hamming

import "errors"

// Distance calculates the Hamming distance of two DNA strands
func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return 0, errors.New("both strands should be of the same size")
	}

	count := 0
	len := len(a)

	for index := 0; index < len; index++ {
		if a[index] != b[index] {
			count++
		}
	}

	return count, nil
}
