package secret

import (
	"slices"
)

func Handshake(code uint) []string {
	result := []string{}

	if (code & 0x01) != 0 {
		result = append(result, "wink")
	}

	if (code & 0x02) != 0 {
		result = append(result, "double blink")
	}

	if (code & 0x04) != 0 {
		result = append(result, "close your eyes")
	}

	if (code & 0x08) != 0 {
		result = append(result, "jump")
	}

	if (code & 0x10) != 0 {
		slices.Reverse(result)
	}

	return result
}
