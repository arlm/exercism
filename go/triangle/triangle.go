// Package triangle enables to differentiate triangle types and
// also if it is a triangle at all
package triangle

import "math"

// Kind enumeration specifies the type of triangle that was identified.
type Kind int

const (
	// NaT means: not a triangle
	NaT Kind = iota

	// Equ means: equilateral triangle (three equal sides)
	Equ

	// Iso means: isosceles triangle (two equal sides)
	Iso

	// Sca means: scalene triangle (no equal sides)
	Sca

	// Dgn means: degenerate triagle (has zero area and looks like a line)
	Dgn
)

// KindFromSides identiifies the type of triangle by its side measurements.
func KindFromSides(a, b, c float64) Kind {
	zeroes := a == 0 || b == 0 || c == 0
	notANumber := math.IsNaN(a) || math.IsNaN(b) || math.IsNaN(c)
	infinities := math.IsInf(a, 0) || math.IsInf(b, 0) || math.IsInf(c, 0)

	if zeroes || notANumber || infinities {
		return NaT
	}

	abLengthDegenerate := a+b == c
	acLengthDegenerate := a+c == b
	bcLengthDegenerate := b+c == a

	if abLengthDegenerate || acLengthDegenerate || bcLengthDegenerate {
		return Dgn
	}

	abLengthValid := a+b > c
	acLengthValid := a+c > b
	bcLengthValid := b+c > a

	if !(abLengthValid && acLengthValid && bcLengthValid) {
		return NaT
	}

	ab := a == b
	ac := a == c
	bc := b == c

	if ab && bc {
		return Equ
	}

	if ab || ac || bc {
		return Iso
	}

	return Sca
}
