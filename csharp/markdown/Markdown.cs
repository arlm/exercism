using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private const string HTML_ITALIC = "em";
    private const string HTML_BOLD = "strong";
    private const string HTML_PARAGRAPH = "p";
    private const string HTML_LIST = "li";

    private const char MARKDOWN_HEADER = '#';
    private const char MARKDOWN_LIST_ITEM = '*';
    private const string MARKDOWN_BOLD = "__";
    private const string MARKDOWN_ITALIC = "_";

    private static string Wrap(this string text, string tag) =>
        $"<{tag}>{text}</{tag}>";

    private static string Parse(this string markdown, string delimiter, string tag) =>
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string MaybeCloseList(this string value, bool isInList) =>
        isInList ? $"</ul>{value}" : value;

    private static string MaybeOpenList(this string innerHtml, bool isInList) =>
        isInList ? innerHtml : $"<ul>{innerHtml}";

    private static (string, bool) ParseLine(string markdown, bool list)
    {
        markdown = markdown.Parse(MARKDOWN_BOLD, HTML_BOLD);
        markdown = markdown.Parse(MARKDOWN_ITALIC, HTML_ITALIC);

        string result = null;
        bool isInList = list;

        if (markdown.StartsWith(MARKDOWN_HEADER))
        {
            var count = markdown.TakeWhile(@char => @char == MARKDOWN_HEADER).Count();
            var headerHtml = markdown.Substring(count + 1).Wrap($"h{count}");

            result = headerHtml.MaybeCloseList(isInList);
            isInList = false;
        }

        if (markdown.StartsWith(MARKDOWN_LIST_ITEM))
        {
            result = markdown.Substring(2).Wrap(HTML_LIST).MaybeOpenList(list);
            isInList = true;
        }

        if (result == null)
        {
            result = markdown.Wrap(HTML_PARAGRAPH).MaybeCloseList(isInList);
            isInList = false;
        }

        return (result ?? throw new ArgumentException("Invalid markdown"), isInList);
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split(Environment.NewLine);
        var sb = new StringBuilder();
        var list = false;

        foreach (var line in lines)
        {
            (var lineResult, var inListAfter) = ParseLine(line, list);
            list = inListAfter;
            sb.Append(lineResult);
        }

        return list ? $"{sb}</ul>" : sb.ToString();
    }
}