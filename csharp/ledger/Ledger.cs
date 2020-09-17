using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, decimal chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public decimal Chg { get; }
}

public static class Ledger
{
    private const string LOCALE_US = "en-US";
    private const string LOCALE_NL = "nl-NL";

    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        string curSymb = null;
        int curNeg = 0;
        string datPat = null;

        if (cur != "USD" && cur != "EUR")
        {
            throw new ArgumentException("Invalid currency");
        }
        else
        {
            if (loc != LOCALE_NL && loc != LOCALE_US)
            {
                throw new ArgumentException("Invalid currency");
            }

            if (cur == "USD")
            {
                if (loc == LOCALE_US)
                {
                    curSymb = "$";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == LOCALE_NL)
                {
                    curSymb = "$";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }

            if (cur == "EUR")
            {
                if (loc == LOCALE_US)
                {
                    curSymb = "€";
                    datPat = "MM/dd/yyyy";
                }
                else if (loc == LOCALE_NL)
                {
                    curSymb = "€";
                    curNeg = 12;
                    datPat = "dd/MM/yyyy";
                }
            }
        }

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
        return culture;
    }

    private static string PrintHead(string loc)
    {
        if (loc == LOCALE_US)
        {
            return "Date       | Description               | Change       ";
        }

        else
        {
            if (loc == LOCALE_NL)
            {
                return "Datum      | Omschrijving              | Verandering  ";
            }
            else
            {
                throw new ArgumentException("Invalid locale");
            }
        }
    }

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc)
    {
        if (desc.Length > 25)
        {
            var trunc = desc.Substring(0, 22);
            trunc += "...";
            return trunc;
        }

        return desc;
    }

    private static string Change(IFormatProvider culture, decimal cgh) =>
        cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry) =>
        $"{Date(culture, entry.Date)} | {Description(entry.Desc),-25} | { Change(culture, entry.Chg),13}";


    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
        var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

        return neg.Union(post);
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = "";
        formatted += PrintHead(locale);

        var culture = CreateCulture(currency, locale);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);

            for (var i = 0; i < entriesForOutput.Count(); i++)
            {
                formatted += "\n" + PrintEntry(culture, entriesForOutput.Skip(i).First());
            }
        }

        return formatted;
    }
}
