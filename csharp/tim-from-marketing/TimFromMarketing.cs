using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var departmentText = department?.ToUpper() ?? "OWNER";

        if (id.HasValue)
        {
            return $"{name} - {departmentText}";
        }

        return $"[{id}] - {name} - {departmentText}";
    }
}
