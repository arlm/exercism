using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var sb = new StringBuilder();


        for (int count = startBottles; takeDown > 0; takeDown--, count--)
        {
            sb.AppendFirstVerse(count);
            sb.AppendSecondVerse(count);

            if (takeDown > 1)
            {
                sb  
                    .AppendNewLine()
                    .AppendNewLine();
            }
        }

        return sb.ToString();
    }

    private static StringBuilder AppendNumberOfBottles(this StringBuilder sb, int startBottles, bool beginSentence) =>
        startBottles > 0 ?
            sb.Append(startBottles)
        :
            beginSentence ?
                sb.Append("No more")
            :
                sb.Append("no more");

    private static StringBuilder AppendBottlesOfBeer(this StringBuilder sb, int startBottles) => sb
        .Append(startBottles == 1 ? " bottle" : " bottles")
        .Append(" of beer");

    private static StringBuilder AppendOneOrIt(this StringBuilder sb, int startBottles) => sb
       .Append(startBottles == 1 ? "it" : "one");

    private static StringBuilder AppendNewLine(this StringBuilder sb) => sb
        .Append("\n");

    private static StringBuilder AppendFirstVerse(this StringBuilder sb, int startBottles) => sb
        .AppendNumberOfBottles(startBottles, true)
        .AppendBottlesOfBeer(startBottles)
        .AppendFormat(" on the wall, ")
        .AppendNumberOfBottles(startBottles, false)
        .AppendBottlesOfBeer(startBottles)
        .Append(".")
        .AppendNewLine();

    private static StringBuilder AppendSecondVerse(this StringBuilder sb, int startBottles) =>
        startBottles == 0 ?
            sb
            .Append("Go to the store and buy some more, 99 bottles of beer on the wall.")
        :
            sb        
            .AppendFormat("Take ")
            .AppendOneOrIt(startBottles)
            .Append(" down and pass it around, ")
            .AppendNumberOfBottles(--startBottles, false)
            .AppendBottlesOfBeer(startBottles)
            .AppendFormat(" on the wall.");
}