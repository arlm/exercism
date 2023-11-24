using System;
using System.Collections.Generic;
using System.Linq;

public enum Protein
{
    Unknown,
    Methionine,
    Phenylalanine,
    Leucine,
    Serine,
    Tyrosine,
    Cysteine,
    Tryptophan,
    Stop
}

public static class ProteinTranslation
{
    public static readonly Dictionary<string, Protein> translationDictionary = new Dictionary<string, Protein>
    {
        { "AUG", Protein.Methionine },
        { "UUU", Protein.Phenylalanine},
        { "UUC", Protein.Phenylalanine},
        { "UUA", Protein.Leucine},
        { "UUG", Protein.Leucine},
        { "UCU", Protein.Serine},
        { "UCC", Protein.Serine},
        { "UCA",  Protein.Serine},
        { "UCG", Protein.Serine},
        { "UAU", Protein.Tyrosine},
        { "UAC", Protein.Tyrosine},
        { "UGU", Protein.Cysteine},
        { "UGC", Protein.Cysteine},
        { "UGG", Protein.Tryptophan},
        { "UAA", Protein.Stop},
        { "UAG", Protein.Stop},
        { "UGA", Protein.Stop}
    };

    public static string[] Proteins(string strand) {
        if (string.IsNullOrEmpty(strand)) {
            return new string[] {};
        }

        return strand.Length % 3 != 0
            ? throw new ArgumentException($"Invalid strand. Length ({strand.Length}) should be multiple of three (3)", nameof(strand)) 
            : strand.GetProteins().Select(protein => protein.ToString("G")).ToArray();
    }

    public static (Protein, string) GetCodon(this string strand)
    {
        var codon = strand.Substring(0, 3).ToUpper();
        var remainingStrand = strand.Substring(3);

        return translationDictionary.ContainsKey(codon)
            ? (translationDictionary[codon], remainingStrand)
            : throw new ArgumentException($"Invalid codon '{codon}'", nameof(strand));
    }

    public static IEnumerable<Protein> GetProteins(this string strand)
    {
        var rnaStrand = strand;
        while (!string.IsNullOrEmpty(rnaStrand))
        {
            Protein protein;
            (protein, rnaStrand) = rnaStrand.GetCodon();

            if (protein == Protein.Stop)
            {
                yield break;
            }

            yield return protein;
        }
    }
}