import java.util.regex.Matcher;
import java.util.regex.Pattern;

class SqueakyClean {
    static String clean(String identifier) {
        final String kebabRegex = "(-)([a-zA-Z])";
        final Pattern kebabPattern = Pattern.compile(kebabRegex);
        final Matcher kebabMatcher = kebabPattern.matcher(identifier);
        
        final String result = kebabMatcher
            .replaceAll((match) -> match.group(2).toUpperCase())
            .replace(" ", "_")
            .replace("4", "a")
            .replace("3", "e")
            .replace("0", "o")
            .replace("1", "l")
            .replace("7", "t");

        final String nonCharRegex = "[^a-zA-Z_]";
        final Pattern nonCharPattern = Pattern.compile(nonCharRegex);
        final Matcher nonCharMatcher = nonCharPattern.matcher(result);
        
        return nonCharMatcher.replaceAll("");
    }
}
