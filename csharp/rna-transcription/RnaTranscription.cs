using System;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string sequence)
    {
        var sb = new StringBuilder();

        foreach (var nucleotide in sequence)
        {
            switch (nucleotide)
            {
                case 'A':
                    sb.Append('U');
                    break;

                case 'C':
                    sb.Append('G');
                    break;

                case 'G':
                    sb.Append('C');
                    break;

                case 'T':
                    sb.Append('A');
                    break;

                default:
                    throw new ArgumentException($"Invalid nucleotid ({nucleotide}) in sequence: {sequence}", nameof(sequence));
            }
        }

        return sb.ToString();
    }
}