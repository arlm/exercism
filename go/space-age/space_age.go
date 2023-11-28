package space

// Planet enumeration
type Planet string

const (
	// Earth as a planet
	Earth Planet = "Earth"

	// Mercury as a planet
	Mercury = "Mercury"

	// Venus as a planet
	Venus = "Venus"

	// Mars as a planet
	Mars = "Mars"

	// Jupiter as a planet
	Jupiter = "Jupiter"

	// Saturn as a planet
	Saturn = "Saturn"

	// Uranus as a planet
	Uranus = "Uranus"

	// Neptune as a planet
	Neptune = "Neptune"
)

func (p Planet) float64() float64 {
	values := map[string]float64{"Earth": 1.0, "Mercury": 0.2408467, "Venus": 0.61519726, "Mars": 1.8808158, "Jupiter": 11.862615, "Saturn": 29.447498, "Uranus": 84.016846, "Neptune": 164.79132}

	x := string(p)

	if val, ok := values[x]; ok {
		return val
	}

	return -1
}

// year is 365.25 Earth days, or 31557600 seconds
const year = float64(31557600)

// Age function calculates the age in another planet years
func Age(seconds float64, planet Planet) float64 {
    factor := planet.float64()

    if factor < 0 {
    	return factor
    }

	return float64(seconds) / (year * factor)
}
