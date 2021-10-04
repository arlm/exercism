enum Nucleotides {
  A,
  C,
  G,
  T,
}

type Nucleotid = keyof typeof Nucleotides;
type NucleotidCount = Record<Nucleotid, number>;

export function nucleotideCounts(nucleotids: string): NucleotidCount {
  const map = new Map<string, number>();
  const result: NucleotidCount = { A: 0, C: 0, G: 0, T: 0 };

  nucleotids
    .split("")
    .forEach((char) =>{
      if (!(char in result)) throw new Error("Invalid nucleotide in strand");
      map.has(char) ? map.set(char, map.get(char)! + 1) : map.set(char, 1);
    });


  for (const [key, value] of map.entries()) {
    result[<Nucleotid>key] = value;
  }

  return result;
}
