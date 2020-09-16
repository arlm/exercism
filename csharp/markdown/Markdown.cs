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

    private static string Wrap(string text, string tag) =>
        $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag) =>
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string ParseBold(string markdown) =>
        Parse(markdown, MARKDOWN_BOLD, HTML_BOLD);

    private static string ParseItalic(string markdown) =>
        Parse(markdown, MARKDOWN_ITALIC, HTML_ITALIC);

    private static string ParseParagraph(string markdown) =>
        Wrap(markdown, HTML_PARAGRAPH);

    private static string ParseHeader(string markdown)
    {
        var count = markdown.TakeWhile(@char => @char == MARKDOWN_HEADER).Count();
        var headerHtml = Wrap(markdown.Substring(count + 1), $"h{count}");

        return headerHtml;
    }

    private static string ParseLineItem(string markdown, bool list)
    {
        var innerHtml = Wrap(markdown.Substring(2), HTML_LIST);

        return list ? innerHtml : $"<ul>{innerHtml}";
    }
    
    private static (string, bool) ParseLine(string markdown, bool list)
    {
        markdown = ParseBold(markdown);
        markdown = ParseItalic(markdown);

        string result = null;
        bool isInList = list;

        if (markdown.StartsWith(MARKDOWN_HEADER))
        {
            var value = ParseHeader(markdown);
            result = isInList ? $"</ul>{value}" : value;
            isInList = false;
        }

        if (markdown.StartsWith(MARKDOWN_LIST_ITEM))
        {
            result = ParseLineItem(markdown, list);
            isInList = true;
        }

        if (result == null)
        {
            var value = ParseParagraph(markdown);
            result = isInList ? $"</ul>{value}" : value;
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