using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public partial class SimpleCipher
{
    private readonly int limit = 'z' - 'a' + 1;

    public SimpleCipher() {}

    public SimpleCipher(string key) => Key = key;

    public string Key { get; } = Regex
        .Replace(
            input: string.Join(
                separator: string.Empty,
                values: SHA512
                        .HashData(Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString()))
                        .Select(value => value.ToString("x").ToLower())
            ),
            pattern: "[^a-z]",
            replacement: ""
        );

    public string Encode(string plaintext)
    {
        var adjustedKey = AdjustKey(plaintext.Length);

        return string.Join(
            separator: string.Empty,
            values: plaintext
                    .Zip(adjustedKey, (cypher, key) => (Cipher: Denormalize(cypher), Key: Denormalize(key)))
                    .Select(tuple => Normalize(Add(tuple.Cipher, tuple.Key)))
        );
    }

    public string Decode(string ciphertext)
    {
        var adjustedKey = AdjustKey(ciphertext.Length);

        return string.Join(
            separator: string.Empty,
            values: ciphertext
                    .Zip(adjustedKey, (cypher, key) => (Cipher: Denormalize(cypher), Key: Denormalize(key)))
                    .Select(tuple => Normalize(Subtract(tuple.Cipher, tuple.Key)))
        );
    }

    private string AdjustKey(int length)
    {
        var result = Key;

        while (result.Length < length)
        {
            result += Key;
        }

        return result;
    }

    private static char Normalize(char value) => (char)(value + 'a');
    private static char Denormalize(char value) => (char)(value - 'a');

    private char Add(char one, char two) => (char)((one + two) % limit);
    private char Subtract(char one, char two)
    {
        var result = one - two;
        return result < 0 ? (char)(limit + result) : (char)result;
    }
}