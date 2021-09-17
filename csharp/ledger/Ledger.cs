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

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public class Locale
{
    public const string LOCALE_US = "en-US";
    public const string LOCALE_NL = "nl-NL";

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

    public string Date { get; }
    public string Description { get; }
    public string Change { get; }
    public string DateFormat { get; }

    public Locale(string currency, string locale)
    {
        if (currency != CURRENCY_USD && currency != CURRENCY_EUR)
        {
            throw new ArgumentException("Invalid currency");
        }

        switch (locale)
        {
            case LOCALE_US:
                Date = DATE_US;
                Description = DESCRIPTION_US;
                Change = CHANGE_US;
                DateFormat = DATE_FORMAT_US;
                break;

            case LOCALE_NL:
                Date = DATE_NL;
                Description = DESCRIPTION_NL;
                Change = CHANGE_NL;
                DateFormat = DATE_FORMAT_NL;
                break;

            default:
                throw new ArgumentException("Invalid locale");
        }

        var culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = GetCultureInfo(currency).NumberFormat.CurrencySymbol;

        culture.NumberFormat.CurrencyNegativePattern = locale == LOCALE_US
            ? 0
            : culture.NumberFormat.CurrencyNegativePattern;

        culture.DateTimeFormat.ShortDatePattern = locale == LOCALE_US
            ? DATE_FORMAT_US
            : DATE_FORMAT_NL;

        Thread.CurrentThread.CurrentCulture = culture;
    }

    private static CultureInfo GetCultureInfo(string currency) =>
         CultureInfo.GetCultures(CultureTypes.SpecificCultures)
         .Where(cultureInfo =>
         {
             try
             {
                 return new RegionInfo(cultureInfo.LCID).ISOCurrencySymbol == currency;
             }
             catch
             {
                 return false;
             }
         }).First();
}

public static class Ledger
{
    private static string TrimWithEllipsis(this string description) =>
        description.Length <= 25 ? $"{description,-25}" : $"{description.Substring(0, 22)}...";

    private static string Pad(this decimal change) =>
        change < 0.0m ? $"{change,13:C}" : $"{change,12:C} ";

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var localeFormatter = new Locale(currency, locale);
        var sb = new StringBuilder($"{localeFormatter.Date,-10} | {localeFormatter.Description,-25} | {localeFormatter.Change,-13}");

        if (entries.Length == 0)
        {
            return sb.ToString();
        }

        var items = entries
            .OrderBy(entry => entry.Change < 0 ? -1 : 1).ThenBy(entry => entry.Date).ThenBy(entry => entry.Description).ThenBy(entry => entry.Change)
            .Select(entry => $"\n{entry.Date:d} | {entry.Description.TrimWithEllipsis()} | {entry.Change.Pad()}");

        return sb.AppendJoin(string.Empty, items).ToString();
    }

    public static LedgerEntry CreateEntry(string date, string description, int change) =>
        new LedgerEntry(
            DateTime.Parse(date, CultureInfo.InvariantCulture),
            description,
            change / 100.0m);

    public static LedgerEntry CreateEntry(string date, string description, decimal change) =>
        new LedgerEntry(
            DateTime.Parse(date, CultureInfo.InvariantCulture),
            description,
            change);
}
