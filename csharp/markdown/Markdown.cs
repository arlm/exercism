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

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        if (!markdown.StartsWith(MARKDOWN_HEADER))
        {
            inListAfter = list;
            return null;
        }

        inListAfter = false;

        var count = markdown.TakeWhile(@char => @char == MARKDOWN_HEADER).Count();
        var headerHtml = Wrap(markdown.Substring(count + 1), $"h{count}");

        return list ? $"</ul>{headerHtml}" : headerHtml;
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith(MARKDOWN_LIST_ITEM))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), TAG_LIST);

            inListAfter = true;

            return list ? innerHtml : $"<ul>{innerHtml}";
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        if (!list)
        {
            inListAfter = false;
            return ParseText(markdown, list);
        }
        else
        {
            inListAfter = false;
            var parsedText = ParseText(markdown, false);
            return $"</ul>{parsedText}";
        }
    }


    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter) =>
        ParseHeader(markdown, list, out inListAfter) ??
        ParseLineItem(markdown, list, out inListAfter) ??
        ParseParagraph(markdown, list, out inListAfter) ??
        throw new ArgumentException("Invalid markdown");

    public static string Parse(string markdown)
    {
        var lines = markdown.Split(Environment.NewLine);
        var sb = new StringBuilder();
        var list = false;

        for (int i = 0; i < lines.Length; i++)
        {
            var lineResult = ParseLine(lines[i], list, out list);
            sb.Append(lineResult);
        }

        var result = sb.ToString();
        return list ? $"{result}</ul>" : result;
    }
}