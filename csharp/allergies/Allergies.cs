using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen allergies;

    public Allergies(int mask)
    {
        allergies = (Allergen)unchecked((byte)mask);
    }

    public bool IsAllergicTo(Allergen allergen) => allergies.HasFlag(allergen);

    public Allergen[] List()
    {
        var result = new List<Allergen>();

        if (allergies.HasFlag(Allergen.Eggs))
        {
            result.Add(Allergen.Eggs);
        }

        if (allergies.HasFlag(Allergen.Peanuts))
        {
            result.Add(Allergen.Peanuts);
        }

        if (allergies.HasFlag(Allergen.Shellfish))
        {
            result.Add(Allergen.Shellfish);
        }

        if (allergies.HasFlag(Allergen.Strawberries))
        {
            result.Add(Allergen.Strawberries);
        }

        if (allergies.HasFlag(Allergen.Tomatoes))
        {
            result.Add(Allergen.Tomatoes);
        }

        if (allergies.HasFlag(Allergen.Chocolate))
        {
            result.Add(Allergen.Chocolate);
        }

        if (allergies.HasFlag(Allergen.Pollen))
        {
            result.Add(Allergen.Pollen);
        }

        if (allergies.HasFlag(Allergen.Cats))
        {
            result.Add(Allergen.Cats);
        }

        return result.ToArray();
    }
}