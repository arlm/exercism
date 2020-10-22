using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects) => MakeProverb(subjects).ToArray();

    private static IEnumerable<string> MakeProverb(IEnumerable<string> subjects)
    {
        if (!subjects.Any())
        {
            yield break;
        }

        IEnumerable<string> temp = subjects;
        IEnumerable<string> sentence;

        while ((sentence = temp.Take(2)).Count() == 2)
        {
            yield return $"For want of a {sentence.First()} the {sentence.Last()} was lost.";
            temp = temp.Skip(1);
        }

        yield return $"And all for the want of a {subjects.First()}.";
    }
}