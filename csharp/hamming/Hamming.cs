using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        var distance = 0;

        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Strands have different sizes.");
        }

        for (int index = 0; index < firstStrand.Length; index++)
        {
            if (firstStrand[index] != secondStrand[index])
            {
                distance++;
            }
        }

        return distance;
    }
}