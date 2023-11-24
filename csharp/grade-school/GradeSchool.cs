using System;
using System.Collections.Generic;
using System.Linq;

public struct Entry
{
    public string Name;
    public int Grade;
}

public class GradeSchool
{

    private List<Entry> entries = new List<Entry>();

    public bool Add(string student, int grade) {
        if (entries.Any(entry => entry.Name == student)) {
            return false;
        }

        entries.Add(new Entry
        {
            Name = student,
            Grade = grade
        });

        return true;
    }

    public IEnumerable<string> Roster() =>
        entries
            .OrderBy(entry => entry.Grade).ThenBy(entry => entry.Name)
            .Select(entry => entry.Name);

    public IEnumerable<string> Grade(int grade) =>
        entries
            .Where(entry => entry.Grade == grade)
            .OrderBy(entry => entry.Name)
            .Select(entry => entry.Name);
}