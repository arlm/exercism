using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private const string TAG_ITALIC = "em";
    private const string TAG_BOLD = "strong";
    private const string TAG_PARAGRAPH = "p";
    private const string TAG_LIST = "li";

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
        var count = 0;

        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count += 1;
            }
            else
            {
                break;
            }
        }

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        var headerTag = $"h{count}";
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        if (list)
        {
            inListAfter = false;
            return $"</ul>{headerHtml}";
        }
        else
        {
            inListAfter = false;
            return headerHtml;
        }
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), TAG_LIST);

            if (list)
            {
                inListAfter = true;
                return innerHtml;
            }
            else
            {
                inListAfter = true;
                return $"<ul>{innerHtml}";
            }
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

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        var result = ParseHeader(markdown, list, out inListAfter);

        if (result == null)
        {
            result = ParseLineItem(markdown, list, out inListAfter);
        }

        if (result == null)
        {
            result = ParseParagraph(markdown, list, out inListAfter);
        }

        return result ?? throw new ArgumentException("Invalid markdown");
    }

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