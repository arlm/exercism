using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        bool hasFoundNonDigit = false;
        var cleanString = new StringBuilder();

        for (int index = 0; index < identifier.Length; index++) {
            char character = identifier[index];

            if (!hasFoundNonDigit && char.IsDigit(character))
            {
                continue;
            }

            // From Unicode Greek and Coptic character table
            // http://unicode.org/charts/PDF/U0370.pdf
            if (character >= '\u0370' && character <= '\u03FF')
            {
                if (char.IsLower(character))
                {
                    continue;
                }
            }

            if (char.IsControl(character))
            {
                cleanString.Append("CTRL");
            } else if (char.IsWhiteSpace(character))
            {
                cleanString.Append('_');
            }
            else if (character == '-')
            {
                index++;

                if (index < identifier.Length)
                {
                    character = identifier[index];
                    cleanString.Append(char.ToUpper(character));
                }
            }
            else
            {
                if (char.IsLetterOrDigit(character))
                {
                    cleanString.Append(character);
                }
            }
        }

        return cleanString.ToString();
    }
}
