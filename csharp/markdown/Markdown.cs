using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private const string TAG_ITALIC = "em";
    private const string TAG_BOLD = "strong";
    private const string TAG_PARAGRAPH = "p";
    private const string TAG_LIST = "li";
    private const char MARKDOWN_HEADER = '#';
    private const char MARKDOWN_LIST_ITEM = '*';

    private static string Wrap(string text, string tag) =>
        $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag) =>
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string ParseBold(string markdown) =>
        Parse(markdown, "__", TAG_BOLD);

    private static string ParseItalic(string markdown) =>
        Parse(markdown, "_", TAG_ITALIC);

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = ParseItalic(ParseBold(markdown));

        return list ? parsedText : Wrap(parsedText, TAG_PARAGRAPH);
    }

    private static string ParseHeader(string markdown, bool list)
    {
        var count = markdown.TakeWhile(@char => @char == MARKDOWN_HEADER).Count();
        var headerHtml = Wrap(markdown.Substring(count + 1), $"h{count}");

        return list ? $"</ul>{headerHtml}" : headerHtml;
    }

    private static string ParseLineItem(string markdown, bool list)
    {
        var innerHtml = Wrap(ParseText(markdown.Substring(2), true), TAG_LIST);

        return list ? innerHtml : $"<ul>{innerHtml}";
    }

    private static string ParseParagraph(string markdown, bool list)
    {
        var parsedText = ParseText(markdown, false);

        return list ? $"</ul>{parsedText}" : parsedText;
    }

    private static (string, bool) ParseLine(string markdown, bool list)
    {
        string result = null;
        bool inListAfter = false;

        if (markdown.StartsWith(MARKDOWN_HEADER))
        {
            result = ParseHeader(markdown, list);
            inListAfter = false;
        }

        if (markdown.StartsWith(MARKDOWN_LIST_ITEM))
        {
            result = ParseLineItem(markdown, list);
            inListAfter = true;
        }

        if (result == null)
        {
            result = ParseParagraph(markdown, list);
            inListAfter = false;
        }

        return (result ?? throw new ArgumentException("Invalid markdown"), inListAfter);
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