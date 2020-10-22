using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var result = new Dictionary<char, int>
        {
            { 'A' , 0 },
            { 'C' , 0 },
            { 'G' , 0 },
            { 'T' , 0 }
        };

        foreach (var nucleotide in sequence)
        {
            switch(nucleotide)
            {
                case 'A':
                    result['A']++;
                    break;

                case 'C':
                    result['C']++;
                    break;

                case 'G':
                    result['G']++;
                    break;

                case 'T':
                    result['T']++;
                    break;

                default:
                    throw new ArgumentException($"Invalid nucleotid ({nucleotide}) in sequence: {sequence}", nameof(sequence));
            }
        }

        return result;
    }
}