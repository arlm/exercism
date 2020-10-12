using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var sb = new StringBuilder();


        for (int count = startBottles; takeDown > 0; takeDown--, count--)
        {
            if (count > 2)
            {
                Verse(count, sb);
            }
            else if (count == 2)
            {
                VerseTwo(sb);
            }
            else if (count == 1)
            {
                VerseOne(sb);
            }
            else
            {
                VerseZero(sb);
            }

            if (takeDown > 1)
            {
                sb.AppendLine(string.Empty);
                sb.AppendLine(string.Empty);
            }
        }

        return sb.ToString();
    }

    private static void Verse(int startBottles, StringBuilder sb)
    {
        sb.AppendFormat("{0} bottles of beer on the wall, {0} bottles of beer.", startBottles);
        sb.AppendLine(string.Empty);
        startBottles--;
        sb.AppendFormat("Take one down and pass it around, {0} bottles of beer on the wall.", startBottles);
    }

    private static void VerseTwo(StringBuilder sb)
    {
        sb.AppendLine("2 bottles of beer on the wall, 2 bottles of beer.");
        sb.Append("Take one down and pass it around, 1 bottle of beer on the wall.");
    }

    private static void VerseOne(StringBuilder sb)
    {
        sb.AppendLine("1 bottle of beer on the wall, 1 bottle of beer.");
        sb.Append("Take it down and pass it around, no more bottles of beer on the wall.");
    }

    private static void VerseZero(StringBuilder sb)
    {
        sb.AppendLine("No more bottles of beer on the wall, no more bottles of beer.");
        sb.Append("Go to the store and buy some more, 99 bottles of beer on the wall.");
    }
}