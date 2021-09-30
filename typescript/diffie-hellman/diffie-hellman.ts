export class DiffieHellman {
  private readonly p: number;
  private readonly g: number;

  constructor(p: number, g: number) {
    const primes = Array.from(this.generatePrimes(Math.max(p, g)));
    
    if (!primes.includes(p) || !primes.includes(g)) {
      throw new Error("Parameters P and G should be primes.");
    }

    this.p = p;
    this.g = g;
  }

  public getPublicKey(privateKey: number): number {
    if (privateKey <= 1) {
      throw new Error("Invalid private key (must be bigger than one).");
    }

    if (privateKey >= this.p) {
      throw new Error("Invalid private key (must be lower than the parameter P).");
    }

    return this.g**privateKey % this.p;
  }

  public getSecret(theirPublicKey: number, myPrivateKey: number): number {
    return theirPublicKey**myPrivateKey % this.p;
  }

  private *generatePrimes(count: number): Iterable<number> {
    var candidate = 1;
    if (count >= 1) yield candidate++;
    if (count >= 2) yield candidate++;
    var primes = [2];
    
    while (candidate <= count) {
      if (primes.every(prime => candidate % prime != 0)) {
        primes.push(candidate);
        yield candidate;
      } 

      candidate += 2;
    }
  }
}
