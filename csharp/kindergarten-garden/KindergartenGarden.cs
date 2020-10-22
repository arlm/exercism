using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly Plant[][] plants;
    private readonly IImmutableList<string> students = new List<string>
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    }.OrderBy( item => item).ToImmutableList();

    public KindergartenGarden(string diagram)
    {
        plants = diagram.Split(new char[] { '\r', '\n' })
            .Select(row => row
                .Select(@char => @char switch
                {
                    'V' => Plant.Violets,
                    'R' => Plant.Radishes,
                    'C' => Plant.Clover,
                    'G' => Plant.Grass,
                    _ => throw new ArgumentOutOfRangeException(nameof(diagram), diagram, $"Plant ({@char}) not known, should be one of: V, R, C, G.")
                }).ToArray()
            ).ToArray();

        if (plants.Count() != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(diagram), diagram, "The diagram should have exactly two lines");
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = students.IndexOf(student) * 2;

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(student), student, $"Student must be one of: {string.Join(", ", students)}");
        }

        var result = new List<Plant>(4);

        result.AddRange(plants[0].Skip(index).Take(2));
        result.AddRange(plants[1].Skip(index).Take(2));

        return result;
    }
}