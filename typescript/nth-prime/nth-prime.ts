export function nth(count: number): number {
  const nthPrime = Array.from(generatePrimes(count)).pop();

  if(!nthPrime) {
    throw new Error("Prime is not possible");
  }

  return  nthPrime;
}

export function *generatePrimes(count: number): Iterable<number> {
  var candidate = 2;
  if (count >= 1) yield candidate++;
  const primes = [2];
  
  while (primes.length < count) {
    if (primes.every(prime => candidate % prime != 0)) {
      primes.push(candidate);
      yield candidate;
    } 

    candidate += 2;
  }
}