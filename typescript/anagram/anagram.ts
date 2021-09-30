export class Anagram {
  private readonly input: string;
  private readonly stats: Map<string, number>;

  constructor(input: string) {
    this.input = input;
    this.stats = this.createMap(input);    
  }

  private createMap(input: string): Map<string, number> {
    const map = new Map<string, number> ();

    [...input].forEach((char: string) => {
      const upperChar = char.toUpperCase();
      if (map.has(upperChar)) {
        const value = map.get(upperChar)!;
        map.set(upperChar, value + 1);
      } else {
        map.set(upperChar, 1);
      }
    });

    return map;
  }

  private isAnagram(candidate: string): boolean {
    if (candidate.toUpperCase() === this.input.toUpperCase()) {
      return false;
    }

    const map = this.createMap(candidate); 
    const result = this.compareMaps(map, this.stats);
    return result;
  }

  private compareMaps<K, V>(map1: Map<K, V>, map2: Map<K, V>) {
    if (map1.size !== map2.size) {
        return false;
    }

    for (var [key, val1] of map1) {
        const val2 = map2.get(key);

        if (val2 !== val1) {
            return false;
        }
    }

    return true;
}

  public matches(...potentials: string[]): string[] {
    return potentials.filter(candidate => this.isAnagram(candidate));
  }
}
