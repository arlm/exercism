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

    public void Add(string student, int grade) =>
        entries.Add(new Entry
            {
                Name = student,
                Grade = grade
            });

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