import java.util.regex.Pattern;

public class LogLevels {

  private static Pattern pattern = Pattern.compile("^\\[(?<level>[a-zA-Z_\\-0-9]+)\\]\\s*:\\s*(?<message>\\S.*)\\s*$");

  public static String message(String logLine) {
    var matches = pattern.matcher(logLine);

    return matches.find()
        ? matches.group("message").trim()
        : null;
  }

  public static String logLevel(String logLine) {
    var matches = pattern.matcher(logLine);

    return matches.find()
        ? matches.group("level").trim().toLowerCase()
        : null;
  }

  public static String reformat(String logLine) {
    var matches = pattern.matcher(logLine);

    return matches.find()
        ? String.format(
            "%s (%s)",
            matches.group("message").trim(),
            matches.group("level").trim().toLowerCase())
        : null;
  }
}
