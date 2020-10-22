using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) =>
        old
        .SelectMany(
            item => item.Value.Select(value => new KeyValuePair<string, int>(value, item.Key))
        ).ToDictionary(item => item.Key.ToLower(), item => item.Value);
}