using System;
using System.Collections.Generic;
using System.Text;

public class Robot
{
    private readonly Random rnd = new Random();
    private static readonly List<string> usedNames = new List<string>();

    public Robot()
    {
        Name = SafeCreateName();
    }

    private string SafeCreateName()
    {
        var name = CreateName();

        while (usedNames.Contains(name))
        {
            name = CreateName();
        }

        usedNames.Add(name);

        return name;
    }

    private string CreateName()
    {
        var sb = new StringBuilder()
            .Append(GetRandomLetter())
            .Append(GetRandomLetter())
            .Append(GetRandomNumber())
            .Append(GetRandomNumber())
            .Append(GetRandomNumber());

        return sb.ToString();
    }

    private char GetRandomLetter() => (char)rnd.Next(65, 91);
    private char GetRandomNumber() => (char)rnd.Next(48, 58);

    public string Name { get; private set; }

    public void Reset() => Name = SafeCreateName();
}