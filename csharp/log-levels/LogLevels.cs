using System;

static class LogLine
{
    public static string Message(string logLine) => logLine.Substring(logLine.IndexOf(':') + 1).Trim();

    public static string LogLevel(string logLine) => logLine.Substring(1, logLine.IndexOf(']') - 1).ToLower();

    public static string Reformat(string logLine) => string.Format("{0} ({1})", Message(logLine), LogLevel(logLine));
}
