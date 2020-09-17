using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public LedgerEntry(string date, string description, int change)
    {
        Date = DateTime.Parse(date, CultureInfo.InvariantCulture);
        Description = description;
        Change = change / 100.0m;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
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

    private static void CreateCulture(string currency, string locale)
    {
        if (currency != CURRENCY_USD && currency != CURRENCY_EUR)
        {
            throw new ArgumentException("Invalid currency");
        }

        var culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = GetCultureInfo(currency).NumberFormat.CurrencySymbol;
        culture.NumberFormat.CurrencyNegativePattern = locale == LOCALE_US ? 0 : culture.NumberFormat.CurrencyNegativePattern;
        culture.DateTimeFormat.ShortDatePattern = locale == LOCALE_US ? DATE_FORMAT_US : DATE_FORMAT_NL;

        Thread.CurrentThread.CurrentCulture = culture;
    }

    private static CultureInfo GetCultureInfo(string currency) =>
        CultureInfo.GetCultures(CultureTypes.SpecificCultures)
        .Where(x =>
        {
            try
            {
                return new RegionInfo(x.LCID).ISOCurrencySymbol == currency;
            }
            catch
            {
                return false;
            }
        }).First();

    private static string TrimWithEllipsis(this string description) =>
        description.Length <= 25 ? $"{description,-25}" : $"{description.Substring(0, 22)}...";

    private static string Pad(this decimal change) =>
        change < 0.0m ? $"{change,13:C}" : $"{change,12:C} ";

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var sb = new StringBuilder(
            locale switch
            {
                LOCALE_US => $"{DATE_US,-10} | {DESCRIPTION_US,-25} | {CHANGE_US,-13}",
                LOCALE_NL => $"{DATE_NL,-10} | {DESCRIPTION_NL,-25} | {CHANGE_NL,-13}",
                _ => throw new ArgumentException("Invalid locale")
            });

        if (entries.Length == 0)
        {
            return sb.ToString();
        }

        CreateCulture(currency, locale);

        var negatives = entries.Where(e => e.Change < 0).OrderBy(x => x.Date).ThenBy(x => x.Description).ThenBy(x => x.Change);
        var positives = entries.Where(e => e.Change >= 0).OrderBy(x => x.Date).ThenBy(x => x.Description).ThenBy(x => x.Change);
        var entriesForOutput = negatives.Union(positives).ToArray();

        for (var index = 0; index < entriesForOutput.Count(); index++)
        {
            var entry = entriesForOutput.Skip(index).First();
            sb.AppendFormat("\n{0:d} | {1} | {2}",
                entry.Date,
                entry.Description.TrimWithEllipsis(),
                entry.Change.Pad()
            );
        }

        return sb.ToString();
    }

}
