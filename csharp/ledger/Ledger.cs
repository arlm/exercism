using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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
    private const string CURRENCY_USD = "USD";
    private const string CURRENCY_EUR = "EUR";
    private const string DATE_US = "Date";
    private const string DATE_NL = "Datum";
    private const string DESCRIPTION_US = "Description";
    private const string DESCRIPTION_NL = "Omschrijving";
    private const string CHANGE_US = "Change";
    private const string CHANGE_NL = "Verandering";
    private const string DATE_FORMAT_US = "MM/dd/yyyy";
    private const string DATE_FORMAT_NL = "dd/MM/yyyy";

    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        if (cur != CURRENCY_USD && cur != CURRENCY_EUR || loc != LOCALE_NL && loc != LOCALE_US)
        {
            throw new ArgumentException("Invalid currency");
        }

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = GetCultureInfo(cur).NumberFormat.CurrencySymbol;
        culture.NumberFormat.CurrencyNegativePattern = loc == LOCALE_US ? 0 : culture.NumberFormat.CurrencyNegativePattern;
        culture.DateTimeFormat.ShortDatePattern = loc == LOCALE_US ? DATE_FORMAT_US : DATE_FORMAT_NL;

        return culture;
    }

    private static CultureInfo GetCultureInfo(string cur) =>
        CultureInfo.GetCultures(CultureTypes.SpecificCultures)
        .Where(x =>
        {
            try
            {
                return new RegionInfo(x.LCID).ISOCurrencySymbol == cur;
            }
            catch
            {
                return false;
            }
        }).First();

    private static string Date(IFormatProvider culture, DateTime date) =>
        date.ToString("d", culture);

    private static string Description(string desc) =>
        desc.Length > 25 ? $"{desc.Substring(0, 22)}..." : desc;

    private static string Change(IFormatProvider culture, decimal cgh) =>
        cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";

    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date).ThenBy(x => x.Desc).ThenBy(x => x.Chg);
        var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date).ThenBy(x => x.Desc).ThenBy(x => x.Chg);

        return neg.Union(post);
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var sb = new StringBuilder(
            locale switch
            {
                LOCALE_US => $"{DATE_US}       | {DESCRIPTION_US}               | {CHANGE_US}       ",
                LOCALE_NL => $"{DATE_NL}      | {DESCRIPTION_NL}              | {CHANGE_NL}  ",
                _ => throw new ArgumentException("Invalid locale")
            });

        var culture = CreateCulture(currency, locale);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);

            for (var i = 0; i < entriesForOutput.Count(); i++)
            {
                var entry = entriesForOutput.Skip(i).First();
                sb.AppendFormat("\n{0} | {1,-25} | {2,13}", Date(culture, entry.Date), Description(entry.Desc), Change(culture, entry.Chg));
            }
        }

        return sb.ToString();
    }
}
