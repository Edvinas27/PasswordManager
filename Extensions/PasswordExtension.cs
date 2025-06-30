using System;
using PasswordManager.Data;

namespace PasswordManager.Extensions;

public static class PasswordExtension
{
    /// <summary>
    /// Maps the PasswordStrength enum to a user-friendly display string.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>Enum converted to friendly string</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string ToDisplayString(this PasswordStrength password) => password switch
    {
        PasswordStrength.VeryWeak => "Very Weak",
        PasswordStrength.Weak => "Weak",
        PasswordStrength.Strong => "Strong",
        PasswordStrength.VeryStrong => "Very Strong",
        _ => throw new ArgumentOutOfRangeException(nameof(password), password, null)
    };
}