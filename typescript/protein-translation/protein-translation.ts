enum Proteins {
  Methionine    = "Methionine",
  Phenylalanine = "Phenylalanine",
  Leucine       = "Leucine",
  Serine        = "Serine",
  Tyrosine      = "Tyrosine",
  Cysteine      = "Cysteine",
  Tryptophan    = "Tryptophan",
  STOP          = "STOP",
}

type Protein = keyof typeof Proteins;

export function translate(rna: string): Protein[] {
  if (!rna) {
    throw new Error("Invalid RNA chain");
  }

  const result: Protein[] = [];
  var codon = rna.substring(0, 3);
  rna = rna.substring(3);
  
  if (codon.length != 3) {
     throw new Error(`Invalid codon ${codon.length}`);
  }
  
  while (codon.length == 3) {
    const protein = translateCodon(codon);

    if (protein == Proteins.STOP) {
      break;
    }

    result.push(protein);
    
    codon = rna.substring(0, 3);
    
    if (codon.length == 0) {
      break;
    }
    
    if (codon.length != 3) {
       throw new Error(`Invalid codon ${codon.length}`);
    }

    rna = rna.substring(3);
  }

  return result;
}

function takeNextThree(str: string): string[] {
  let result: string[] = [];
  
  for (let i = 0; i < str.length; i += 3) {
    result.push();
  }
  
  return result;
}

function translateCodon(codon: string): Protein {
  switch (codon[0]) {
    case "A":
      return translate2ndAdenine(codon);

    case "U":
      return translate2ndUracil(codon);

    default:
      throw new Error(`Invalid codon: ${codon}`);
  }
}

function translate2ndAdenine(codon: string): Protein {
  if (codon == "AUG") {
    return Proteins.Methionine;
  }

  throw new Error(`Invalid codon: ${codon}`);
}

function translate2ndUracil(codon: string): Protein {
  switch (codon[1]) {
    case "C":
      return Proteins.Serine;

    case "G":
      return translate3rdGuanine(codon);

    case "A":
      return translate3rdAdenine(codon);

    case "U":
      return translate3rdUracil(codon);

    default:
      throw new Error(`Invalid codon: ${codon}`);
  }
}
function translate3rdUracil(codon: string): Protein {
  switch (codon[2]) {
    case "U":
    case "C":
      return Proteins.Phenylalanine;

    case "G":
    case "A":
      return Proteins.Leucine;

    default:
      throw new Error(`Invalid codon: ${codon}`);
  }
}

function translate3rdAdenine(codon: string): Protein {
  switch (codon[2]) {
    case "U":
    case "C":
      return Proteins.Tyrosine;

    case "G":
    case "A":
      return Proteins.STOP;

    default:
      throw new Error(`Invalid codon: ${codon}`);
  }
}

function translate3rdGuanine(codon: string): Protein {
  switch (codon[2]) {
    case "U":
    case "C":
      return Proteins.Cysteine;

    case "G":
      return Proteins.Tryptophan;

    case "A":
      return Proteins.STOP;

    default:
      throw new Error(`Invalid codon: ${codon}`);
  }
}
