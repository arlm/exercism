export function calculatePrimeFactors(toFactor: number): number[] {
  return [...generatePrimes(toFactor)];
}

function *generatePrimes(toFactor: number): Iterable<number> {
  var candidate = 3;
  var primes = [2];
  var result = toFactor;

  if (toFactor >= 2) {
    yield *makeFactors(toFactor, 2);
  }

  if (result == 1) {
    result;
  }

  const limite = toFactor**0.5 * 3;

  while (candidate <= limite) {
    if (primes.every(prime => candidate % prime != 0)) {
      primes.push(candidate);
      yield *makeFactors(toFactor, candidate);
    } 

    if (result == 1) {
      result;
    }

    candidate += 2;
  }
}

function *makeFactors(toFactor: number, prime: number) {
  while (toFactor > 1 && toFactor % prime == 0) {
    toFactor /= prime;
    yield prime;
  }
}