#include "bob.h"
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>

int ends_with(const char *str, const char *suffix)
{
    if (!str || !suffix)
    {
        return 0;
    }

    size_t lenstr = strlen(str);
    size_t lensuffix = strlen(suffix);

    if (lensuffix > lenstr)
    {
        return 0;
    }

    return strncmp(str + lenstr - lensuffix, suffix, lensuffix) == 0;
}

int is_upper(const char *str)
{
    int foundAlpha = 0;
    int upper = 1;

    for (const char *p = str; *p; p++)
    {
        int alpha = isalpha(*p);
        foundAlpha = foundAlpha || alpha;

        if (alpha)
        {
            upper = upper && isupper(*p);
        }
    }

    return foundAlpha && upper;
}

// Stores the trimmed input string into the given output buffer, which must be
// large enough to store the result.  If it is too small, the output is
// truncated.
size_t trim_whitespace(char *out, size_t len, const char *str)
{
    if (len == 0)
    {
        return 0;
    }

    const char *end;
    size_t out_size;

    // Trim leading space
    while (isspace((unsigned char)*str))
    {
        str++;
    }

    if (*str == 0) // All spaces?
    {
        *out = 0;
        return 1;
    }

    // Trim trailing space
    end = str + strlen(str) - 1;

    while (end > str && isspace((unsigned char)*end))
    {
        end--;
    }

    end++;

    // Set output size to minimum of trimmed string length and buffer size minus 1
    out_size = (size_t)(end - str) < len - 1 ? (size_t)(end - str) : len;

    // Copy trimmed string and add null terminator
    memcpy(out, str, out_size);
    out[out_size] = 0;

    return out_size;
}

char *hey_bob(char *greeting)
{
    size_t length = strlen(greeting);

    if (length == 0)
    {
        return "Fine. Be that way!";
    }

    char *trimmed_string = (char *)malloc(length + 1);
    char *result = NULL;

    trim_whitespace(trimmed_string, length, greeting);

    printf(">> \"%s\" : \"%s\"\n", greeting, trimmed_string);

    if (strlen(trimmed_string) == 0)
    {
        result = "Fine. Be that way!";
    }

    int has_question = ends_with(trimmed_string, "?");
    int is_all_caps = is_upper(trimmed_string);

    if (has_question && is_all_caps)
    {
        result = "Calm down, I know what I'm doing!";
    }
    else if (has_question)
    {
        result = "Sure.";
    }
    else if (is_all_caps)
    {
        result = "Whoa, chill out!";
    }

    free(trimmed_string);

    return result == NULL ? "Whatever." : result;
}
