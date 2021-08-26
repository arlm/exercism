//
// This is only a SKELETON file for the 'Protein Translation' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

const codons = {
  AUG: "Methionine",
  UUU: "Phenylalanine",
  UUC: "Phenylalanine",
  UUA: "Leucine",
  UUG: "Leucine",
  UCU: "Serine",
  UCC: "Serine",
  UCA: "Serine",
  UCG: "Serine",
  UAU: "Tyrosine",
  UAC: "Tyrosine",
  UGU: "Cysteine",
  UGC: "Cysteine",
  UGG: "Tryptophan",
  UAA: "STOP",
  UAG: "STOP",
  UGA: "STOP",
}

export const translate = (rna) => {
  if (!rna) {
    return [];
  }

  var result = new Array();

  for (let index = 0; index < rna.length; index+=3) {
    const codon = rna.substring(index, index+3);
    const protein = codons[codon];

    if (!protein) {
      throw new Error("Invalid codon");
    }    
    
    if (protein === "STOP") {
      break;
    }

    result.push(protein);
  }

  return result;
};
