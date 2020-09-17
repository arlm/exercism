﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

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

    private static string Description(string description) =>
        description.Length > 25 ? $"{description.Substring(0, 22)}..." : description;

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var sb = new StringBuilder(
            locale switch
            {
                LOCALE_US => $"{DATE_US}       | {DESCRIPTION_US}               | {CHANGE_US}       ",
                LOCALE_NL => $"{DATE_NL}      | {DESCRIPTION_NL}              | {CHANGE_NL}  ",
                _ => throw new ArgumentException("Invalid locale")
            });

        if (entries.Length == 0)
        {
            return sb.ToString();
        }

        CreateCulture(currency, locale);

        var negatives = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date).ThenBy(x => x.Desc).ThenBy(x => x.Chg);
        var positives = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date).ThenBy(x => x.Desc).ThenBy(x => x.Chg);
        var entriesForOutput = negatives.Union(positives).ToArray();

        for (var index = 0; index < entriesForOutput.Count(); index++)
        {
            var entry = entriesForOutput.Skip(index).First();
            sb.AppendFormat("\n{0:d} | {1,-25} | {2,13}",
                entry.Date,
                Description(entry.Desc),
                $"{entry.Chg:C}{(entry.Chg < 0.0m ? string.Empty : " ")}"
            );
        }

        return sb.ToString();
    }
}
