using System.Linq;

namespace PasswordManager.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Removes space characters from input string
    /// </summary>
    /// <param name="input">string</param>
    /// <returns>string without space characters</returns>
    public static string RemoveSpaces(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? string.Empty : input.Replace(" ", string.Empty);
    }
}