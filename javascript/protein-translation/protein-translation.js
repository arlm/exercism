//
// This is only a SKELETON file for the 'Protein Translation' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

const codons = {
  A: {U: {G: "Methionine"}},
  U: {
    U: {
      U: "Phenylalanine",
      C: "Phenylalanine",
      A: "Leucine",
      G: "Leucine"
    },
    C: {
      U: "Serine",
      C: "Serine",
      A: "Serine",
      G: "Serine"
    },
    A: { 
      A: "STOP",
      G: "STOP",
      U: "Tyrosine",
      C: "Tyrosine"   
    },
    C: {
      U: "Serine",
      C: "Serine",
      A: "Serine",
      G: "Serine"
    },
    G: {
      A: "STOP",
      U: "Cysteine",
      C: "Cysteine",
      G: "Tryptophan"
    },
  }
}

export const translate = (rna) => {
  if (!rna) {
    return [];
  }

  var result = new Array();

  for (let index = 0; index < rna.length; index++) {
    let nucleodid = rna[index];
    let token = codons[nucleodid];

    if (!token) {
      throw new Error("Invalid codon");
    }  

    nucleodid = rna[++index];
    token = token[nucleodid];

    if (!token) {
      throw new Error("Invalid codon");
    }  
    
    nucleodid = rna[++index];
    const protein = token[nucleodid];

    if (protein === "STOP") {
      break;
    }

    result.push(protein);
  }

  return result;
};
