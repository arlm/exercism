enum DnaBasis {
  G = 'C',
  C = 'G',
  T = 'A',
  A = 'U',
}

type DnaBase = keyof typeof DnaBasis;

export function toRna(dna: string): string {
  if (!dna.match(/^[ACGT]*$/g)) {  
    throw new Error('Invalid input DNA.');
  }

  return dna.replace(/./g, (match, _offset, _string) => (<any>DnaBasis)[match]);
}
