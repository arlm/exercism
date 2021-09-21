using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var departmentText = department?.ToUpper() ?? "OWNER";

        if (id.HasValue)
        {
            return $"[{id}] - {name} - {departmentText}";
        }

        return $"{name} - {departmentText}";
    }
}
