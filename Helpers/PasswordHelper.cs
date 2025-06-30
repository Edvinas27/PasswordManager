using System;
using System.Linq;
using PasswordManager.Data;

namespace PasswordManager.Helpers;

public static class PasswordHelper
{
    /// <summary>
    /// Calculates the strength of a password based on its length and character variety.
    /// Does not check for common passwords or patterns.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>Enum value of password strength</returns>
    public static PasswordStrength CalculateEntropy(string password)
    {
        var data = (
            Length: password.Length,
            HasUpper: password.Any(char.IsUpper),
            HasLower: password.Any(char.IsLower),
            HasDigit: password.Any(char.IsDigit),
            HasSpecial: password.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
        );

        var possibleCharacters = 0;
        
        
        //values taken from nordvpn
        if (data.HasUpper) possibleCharacters += 26;
        if (data.HasLower) possibleCharacters += 26;
        if (data.HasDigit) possibleCharacters += 10;
        if (data.HasSpecial) possibleCharacters += 32;
        
        var entropy = data.Length * Math.Log2(Math.Max(1, possibleCharacters));

        return entropy switch
        {
            < 35 => PasswordStrength.VeryWeak,
            < 59 => PasswordStrength.Weak,
            < 119 => PasswordStrength.Strong,
            >= 119 => PasswordStrength.VeryStrong,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}